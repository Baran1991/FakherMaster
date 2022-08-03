using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
//using Accusoft.BarcodeXpressSdk;
using Accusoft.FormDirectorSdk;
using Accusoft.FormFixSdk;
using Accusoft.ScanFixXpressSdk;
using rComponents;
using rTwain;
using stdole;
//using LicenseChoice = Accusoft.BarcodeXpressSdk.LicenseChoice;

namespace rFormProcessor
{
    public class rFormProcessor : IDisposable
    {
        private FormFix formFix;
        private FormDirector director;
        private FormSetFile formSet;
        private ScanFix scanFix;
        private OmrProcessor processor;
        private IdentificationProcessor identificationProcessor;

        private int mSegmentPerField;
        private int mBubblePerSegment;

        public event EventHandler<ItemEventArgs<Image>> ShowDebugItem;
        public event EventHandler<ItemEventArgs<ProcessStep>> ProcessStep;
        public int MarkedThreshold { get; set; }

        public int MinimumIdentificationConfidence
        {
            get
            {
                return identificationProcessor.MinimumIdentificationConfidence;
            }
            set
            {
                identificationProcessor.MinimumIdentificationConfidence = value;
            }
        }

        public rFormProcessor()
        {
            formFix = new FormFix();
            formFix.Licensing.UnlockRuntime(1288807056, 1989021214, 779757728, 43639);
            formFix.Licensing.LicenseEdition = LicenseEditionType.Professional;

            director = new FormDirector();
            director.License.UnlockRuntime(1288946806, 1988999182, 780924128, 43320);

            scanFix = new ScanFix();
            scanFix.License.UnlockRuntime(1289410310, 1989021214, 780737504, 43012);
            scanFix.License.LicenseEdition = License.LicenseChoice.BitonalPlusColorEdition;

            mSegmentPerField = 1;
            mBubblePerSegment = 4;
            MarkedThreshold = 45;

            identificationProcessor = new IdentificationProcessor(formFix);
            // default = 100
            identificationProcessor.IdentificationCertainty = 100;
            // default = 100
            identificationProcessor.IdentificationQuality = 100;
            // default = 70
            identificationProcessor.MinimumIdentificationConfidence = 40;
            identificationProcessor.MaximumIdentificationBestMatches = 3;
//            identificationProcessor.EnableIdentificationAdaptation = false; 
            identificationProcessor.IncludeBestMatchesBelowConfidence = true;
            identificationProcessor.IdentifyRotated180 = true;
            identificationProcessor.ReadChecksum += new ReadChecksumEventHandler(identificationProcessor_ReadChecksum);
        }

        private Bitmap PreProcess1(Image image)
        {
            scanFix.FromImage(image);

            //Scanner Brightness: 155
            //Scanner Contrast: 185
            BrightnessContrastOptions contrastOptions = new BrightnessContrastOptions();
            //contrastOptions.TargetContrast = 225;
            //contrastOptions.TargetBrightness = 150;
            scanFix.AutoImageDetergent();
            scanFix.AdjustBrightnessContrast(contrastOptions);
            scanFix.Deskew();

            return scanFix.ToBitmap();
        }

        private Bitmap PreProcess2(Image image)
        {
            scanFix.FromImage(image);
            scanFix.AutoBinarize();
            return scanFix.ToBitmap();
        }

        private Bitmap PreProcess3(Image image)
        {
            scanFix.FromImage(image);

//            scanFix.RemoveBorder();
//            scanFix.RemoveLines();
//            scanFix.Despeckle();

            return scanFix.ToBitmap();
        }

        private Bitmap PreProcess1_2(Image image)
        {
            scanFix.FromImage(image);
            //scanFix.SmoothZoom();
            scanFix.Dilate();
            return scanFix.ToBitmap();
        }

        public void InitializeFormDefinition(Image formImage)
        {
            formSet = new FormSetFile(director);
//            FormDefinition formDefinition = formSet.CreateNewForm();
            FormDefinition formDefinition = new FormDefinitionFile(formSet);
            formSet.FormDefinitions.Add(formDefinition);

            TemplateImage templateImage = new TemplateImage(director);
            templateImage.Bitmap = PreProcess2(PreProcess1(formImage));
            formDefinition.TemplateImages.Add(templateImage);

            //Barcode
            Field field = new Field();
            field.Location = new Rectangle(225, 263, 809, 297);
            field.Construction.Type = "_BARCODE";
            formDefinition.Fields.Add(field);

            AddOMRField(formDefinition, 10, 338, 698, 188, 32, 48); //1-10
            AddOMRField(formDefinition, 10, 338, 1193, 188, 32, 48); //11-20

            AddOMRField(formDefinition, 10, 677, 698, 188, 32, 48); //21-30
            AddOMRField(formDefinition, 10, 677, 1193, 188, 32, 48); //31-40

            AddOMRField(formDefinition, 10, 1020, 698, 118, 32, 48); //41-50
            AddOMRField(formDefinition, 10, 1020, 1193, 118, 32, 48); //51-60

            AddOMRField(formDefinition, 10, 1366, 698, 118, 32, 48); //61-70
            AddOMRField(formDefinition, 10, 1366, 1193, 118, 32, 48); //71-80

            AddOMRField(formDefinition, 10, 1710, 698, 118, 32, 48); //81-90
            AddOMRField(formDefinition, 10, 1710, 1193, 118, 32, 48); //91-100

            AddOMRField(formDefinition, 10, 2052, 698, 118, 32, 48); //101-110
            AddOMRField(formDefinition, 10, 2052, 1193, 118, 32, 48); //111-120


            foreach (FormDefinitionFile definition in formSet.FormDefinitions)
            {
                FormModel formModel = new FormModel(formFix);
                formModel.UserTag = definition;
                formModel.ReadChecksum += new ReadChecksumEventHandler(formModel_ReadChecksum);
                formModel.ReadFormImage += new ReadFormImageEventHandler(formModel_ReadFormImage);
                identificationProcessor.FormModels.Add(formModel);
            }

            processor = new OmrProcessor(formFix);
            processor.Orientation = OmrOrientation.HorizontalSegments;
            processor.BubbleShape = OmrBubbleShape.Rectangle;
            processor.MarkScheme = OmrMarkScheme.SingleMark;
            processor.MarkedBubbleThreshold = MarkedThreshold;
            processor.UnmarkedBubbleThreshold = 16;
            processor.UnmarkedSegmentResult = "0";
            processor.AnalysisComparisonMethod = OmrAnalysisComparisonMethod.None;
            processor.Area = new Rectangle(0, 0, 0, 0);

            for (int i = 0; i < mSegmentPerField; i++)
            {
                OmrSegmentModel segmentModel = new OmrSegmentModel();
                processor.Segments.Add(segmentModel);

                for (int j = 0; j < mBubblePerSegment; j++)
                {
                    OmrBubbleModel bubbleModel = new OmrBubbleModel(j + 1 + "");
                    segmentModel.Bubbles.Add(bubbleModel);
                }
            }

        }

        public void InitializeFormDefinition300(Image formImage)
        {
            formSet = new FormSetFile(director);
//            FormDefinition formDefinition = formSet.CreateNewForm();
            FormDefinition formDefinition = new FormDefinitionFile(formSet);
            formSet.FormDefinitions.Add(formDefinition);

            TemplateImage templateImage = new TemplateImage(director);
            templateImage.Bitmap = PreProcess2(PreProcess1(formImage));
            formDefinition.TemplateImages.Add(templateImage);

            //Barcode
            Field field = new Field();
            field.Location = new Rectangle(157, 265, 807, 346);
            field.Construction.Type = "_BARCODE";
            formDefinition.Fields.Add(field);

            AddOMRField(formDefinition, 10, 270, 686, 184, 29, 47); //1-10
            AddOMRField(formDefinition, 10, 270, 1173, 184, 32, 47); //11-20

            AddOMRField(formDefinition, 10, 613, 686, 184, 29, 47); //21-30
            AddOMRField(formDefinition, 10, 613, 1173, 184, 32, 47); //31-40

            AddOMRField(formDefinition, 10, 958, 686, 184, 29, 47); //41-50
            AddOMRField(formDefinition, 10, 958, 1173, 184, 32, 47); //51-60

            AddOMRField(formDefinition, 10, 1306, 686, 184, 29, 47); //61-70
            AddOMRField(formDefinition, 10, 1306, 1173, 184, 32, 47); //71-80

            AddOMRField(formDefinition, 10, 1651, 686, 184, 29, 47); //81-90
            AddOMRField(formDefinition, 10, 1651, 1173, 184, 32, 47); //91-100

            AddOMRField(formDefinition, 10, 1996, 686, 184, 29, 47); //101-110
            AddOMRField(formDefinition, 10, 1996, 1173, 184, 32, 47); //111-120


            foreach (FormDefinitionFile definition in formSet.FormDefinitions)
            {
                FormModel formModel = new FormModel(formFix);
                formModel.UserTag = definition;
                formModel.ReadChecksum += new ReadChecksumEventHandler(formModel_ReadChecksum);
                formModel.ReadFormImage += new ReadFormImageEventHandler(formModel_ReadFormImage);
                identificationProcessor.FormModels.Add(formModel);
            }

            processor = new OmrProcessor(formFix);
            processor.Orientation = OmrOrientation.HorizontalSegments;
            processor.BubbleShape = OmrBubbleShape.OpenRectangle;
            processor.MarkScheme = OmrMarkScheme.SingleMark;
            processor.MarkedBubbleThreshold = MarkedThreshold;
            processor.UnmarkedBubbleThreshold = 16;
            processor.UnmarkedSegmentResult = "0";
            processor.AnalysisComparisonMethod = OmrAnalysisComparisonMethod.None;
            processor.Area = new Rectangle(0, 0, 0, 0);

            for (int i = 0; i < mSegmentPerField; i++)
            {
                OmrSegmentModel segmentModel = new OmrSegmentModel();
                processor.Segments.Add(segmentModel);

                for (int j = 0; j < mBubblePerSegment; j++)
                {
                    OmrBubbleModel bubbleModel = new OmrBubbleModel(j + 1 + "");
                    segmentModel.Bubbles.Add(bubbleModel);
                }
            }

        }

        public void InitializeFormDefinition2(Image formImage)
        {
            formSet = new FormSetFile(director);
//            FormDefinition formDefinition = formSet.CreateNewForm();
            FormDefinition formDefinition = new FormDefinitionFile(formSet);
            formSet.FormDefinitions.Add(formDefinition);

            TemplateImage templateImage = new TemplateImage(director);
            templateImage.Bitmap = PreProcess2(PreProcess1(formImage));
            formDefinition.TemplateImages.Add(templateImage);

            //Barcode
            Field field = new Field();
            field.Location = new Rectangle(200, 334, 1098, 478);
            field.Construction.Type = "_BARCODE";
            formDefinition.Fields.Add(field);

            AddOMRField(formDefinition, 10, 359, 913, 246, 40, 64); //1-10
            AddOMRField(formDefinition, 10, 359, 1563, 246, 40, 64); //11-20

            AddOMRField(formDefinition, 10, 817, 913, 246, 40, 64); //21-30
            AddOMRField(formDefinition, 10, 817, 1563, 246, 40, 64); //31-40

            AddOMRField(formDefinition, 10, 1275, 913, 246, 40, 64); //41-50
            AddOMRField(formDefinition, 10, 1275, 1563, 246, 40, 64); //51-60

            AddOMRField(formDefinition, 10, 1733, 913, 246, 40, 64); //61-70
            AddOMRField(formDefinition, 10, 1733, 1563, 246, 40, 64); //71-80

            AddOMRField(formDefinition, 10, 2191, 913, 246, 40, 64); //81-90
            AddOMRField(formDefinition, 10, 2191, 1563, 246, 40, 64); //91-100

            AddOMRField(formDefinition, 10, 2649, 913, 246, 40, 64); //101-110
            AddOMRField(formDefinition, 10, 2649, 1563, 246, 40, 64); //111-120


            foreach (FormDefinitionFile definition in formSet.FormDefinitions)
            {
                FormModel formModel = new FormModel(formFix);
                formModel.UserTag = definition;
                formModel.ReadChecksum += new ReadChecksumEventHandler(formModel_ReadChecksum);
                formModel.ReadFormImage += new ReadFormImageEventHandler(formModel_ReadFormImage);
                identificationProcessor.FormModels.Add(formModel);
            }

            processor = new OmrProcessor(formFix);
            processor.Orientation = OmrOrientation.HorizontalSegments;
            processor.BubbleShape = OmrBubbleShape.Rectangle;
            processor.MarkScheme = OmrMarkScheme.SingleMark;
            processor.MarkedBubbleThreshold = MarkedThreshold;
            processor.UnmarkedBubbleThreshold = 16;
            processor.UnmarkedSegmentResult = "0";
            processor.AnalysisComparisonMethod = OmrAnalysisComparisonMethod.None;
            processor.Area = new Rectangle(0, 0, 0, 0);

            for (int i = 0; i < mSegmentPerField; i++)
            {
                OmrSegmentModel segmentModel = new OmrSegmentModel();
                processor.Segments.Add(segmentModel);

                for (int j = 0; j < mBubblePerSegment; j++)
                {
                    OmrBubbleModel bubbleModel = new OmrBubbleModel(j + 1 + "");
                    segmentModel.Bubbles.Add(bubbleModel);
                }
            }

        }

        private void AddOMRField(FormDefinition formDefinition, int count, int startX, int startY, int width, int height, int vDistance)
        {
            int x = startX;
            int y = startY;

            for (int i = 0; i < count; i++)
            {
                Field field = new Field();
                field.Location = new Rectangle(x, y, width, height);
                field.Construction.Type = "_OMR";
                formDefinition.Fields.Add(field);
                y += vDistance;
            }
        }

        public ProcessResult Process(Bitmap unknownBitmap)
        {
            Stopwatch stopwatch = new Stopwatch();
            ProcessResult result = new ProcessResult();


            #region PreProcess
            stopwatch.Start();
            OnProcessStep(global::rFormProcessor.ProcessStep.PreProcess);
            OnShowDebugItem(unknownBitmap);

            Bitmap workingBitmap = TwainImageConverter.ConvertType(unknownBitmap, ImageFormat.Jpeg);
            result.RawImage = new Bitmap(workingBitmap);
            result.ProcessedImage = PreProcess1(workingBitmap);
            OnShowDebugItem(result.ProcessedImage);

            FormImage unknownRawFormImage = FormImage.FromBitmap(PreProcess2(result.ProcessedImage), formFix);
            OnShowDebugItem(unknownRawFormImage.ToBitmap(false));

//            FormImage unknownFormImage = FormImage.FromBitmap(PreProcess3(PreProcess2(result.Image)), formFix);
            FormImage unknownFormImage = FormImage.FromBitmap(PreProcess2(result.ProcessedImage), formFix);
            OnShowDebugItem(unknownFormImage.ToBitmap(false));


            stopwatch.Stop();
            result.PreProcessDuration = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            #endregion

            #region Form Identification && Registeration
            stopwatch.Start();
            OnProcessStep(global::rFormProcessor.ProcessStep.FormIdentification);

            IdentificationResult identificationResult = identificationProcessor.Identify(unknownRawFormImage);
            if (identificationResult.State != IdentificationState.MatchFound)
                throw new Exception("فـــرم پاسخنامه قابل شناسایی نیست.");

            result.IdentificationConfidence = identificationResult.GetConfidence(identificationResult.BestMatches[0].FormModelIndex,
                                                                 identificationResult.BestMatches[1].Orientation);

            
            result.IdentificationConfidence = identificationResult.GetConfidence(identificationResult.FormModelIndex,
                                                                                 identificationResult.DetectedOrientation);

            stopwatch.Stop();
            result.IdentificationDuration = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            #endregion

            #region Read Fiels
            stopwatch.Start();
            OnProcessStep(global::rFormProcessor.ProcessStep.ReadFields);

            FormDefinitionFile identifiedFormDefinition = identificationResult.FormModel.UserTag as FormDefinitionFile;
            DropOutProcessor dropOutProcessor = new DropOutProcessor(formFix);

            // ClipWithoutRescaling --> Clip
            dropOutProcessor.DropOutMethod = DropOutMethod.Clip;
            foreach (Field field in identifiedFormDefinition.Fields)
            {
                int indexOf = identifiedFormDefinition.Fields.IndexOf(field);
                dropOutProcessor.Area = field.Location;
                DropOutResult dropOutResult;
                
                if (field.Construction.Type == "_OMR")
                {
                    try
                    {
//                        processor.FormModel = identificationResult.FormModel;
//                        processor.ClipArea = field.Location;
                        dropOutResult = dropOutProcessor.CreateImageOfField(unknownFormImage,
                                                                            identificationResult.
                                                                                RegistrationResult);
                        OmrFieldResult omrResult = processor.AnalyzeField(dropOutResult.Image);
                        result.Answers += omrResult.Text;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + "(" + indexOf + ")");
                    }
                }
                if (field.Construction.Type == "_BARCODE")
                {
                    dropOutResult = dropOutProcessor.CreateImageOfField(unknownRawFormImage,
                                                    identificationResult.RegistrationResult);
                    Bitmap clipBitmap = dropOutResult.Image.ToBitmap(false);

                    result.IdentifierImage = new Bitmap(clipBitmap);
                    OnShowDebugItem(clipBitmap);

                    ArrayList results = new ArrayList();
                    BarcodeImaging.FullScanPage(ref results, clipBitmap, 100);
                    
                    if(results.Count > 0)
                    {
                        result.Identifier = results[0] + "";
                    }

                    clipBitmap.Dispose();
                }
            }

            stopwatch.Stop();
            result.ReadFieldsDuration = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            #endregion

            workingBitmap.Dispose();
            unknownFormImage.Dispose();
            unknownRawFormImage.Dispose();
            identifiedFormDefinition.Dispose();
            dropOutProcessor.Dispose();
            return result;
        }

        private void OnShowDebugItem(Image image)
        {
            if (ShowDebugItem != null)
                ShowDebugItem(this, new ItemEventArgs<Image> { Item = image });
        }

        private void OnProcessStep(ProcessStep step)
        {
            if (ProcessStep != null)
                ProcessStep(this, new ItemEventArgs<ProcessStep> { Item = step });
        }

        void identificationProcessor_ReadChecksum(object sender, ReadChecksumEventArgs e)
        {
            e.Checksum = formSet.GetPartialHashCode();
        }

        void formModel_ReadChecksum(object sender, ReadChecksumEventArgs e)
        {
            FormModel formModel = sender as FormModel;
            FormDefinitionFile formDefinitionFile = formModel.UserTag as FormDefinitionFile;
            e.Checksum = formDefinitionFile.GetPartialHashCode();
        }

        void formModel_ReadFormImage(object sender, ReadFormImageEventArgs e)
        {
            FormModel formModel = sender as FormModel;
            FormDefinitionFile formDefinitionFile = formModel.UserTag as FormDefinitionFile;
            e.FormImage = FormImage.FromBitmap(formDefinitionFile.TemplateImages[0].Bitmap, formFix);
        }

        public void Dispose()
        {
            formFix.Dispose();
            director.Dispose();
            formSet.Dispose();
            scanFix.Dispose();
            processor.Dispose();
            identificationProcessor.Dispose();
        }

        public IntPtr ToDib(Bitmap bitmap)
        {
            scanFix.FromImage(bitmap);
            return scanFix.ToHdib(false);
        }

        public void Test(Bitmap bitmap)
        {
            ScanFix fix1 = new ScanFix();
            fix1.License.UnlockRuntime(1289410310, 1989021214, 780737504, 43012);
            fix1.License.LicenseEdition = License.LicenseChoice.BitonalPlusColorEdition;
            fix1.FromBitmap(PreProcess1((bitmap)));

            //fix1.SmoothZoom();
            //                    fix1.Dilate();
            //                    fix1.Erode();
            //                    fix1.SmoothObjects();
            //                    fix1.AutoImageDetergent();
            //                    fix1.AdjustBrightnessContrast();
            //                    fix1.Deskew();
            //                    fix1.SmoothZoom();
            //fix1.Dilate();

            Bitmap clipBitmap = fix1.ToBitmap();
            OnShowDebugItem(clipBitmap);
//            Result[] results = barcodeXpress.reader.Analyze(clipBitmap);
        }

    }

    public class ItemEventArgs<T> : EventArgs
    {
        public T Item { get; set; }
    }

    public enum ProcessStep
    {
        [EnumDescription("پیش پردازش")]
        PreProcess,
        [EnumDescription("تشخیص فرم")]
        FormIdentification,
        [EnumDescription("خواندن گزینه ها")]
        ReadFields
    }
}
