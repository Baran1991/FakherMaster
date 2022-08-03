using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Fakher.Core.DomainModel
{
	public class AnswerSheetView
	{
		public AnswerSheetView(bool forReportGenerator, bool color, int choiceCount, int questionCount, int columnCount)
		{
			this.color = color;
			QuestionCount = questionCount;
			ColumnCount = columnCount;
			ChoiceCount = choiceCount;
			if (forReportGenerator)
			{
				BoxW = 8;
				BoxH = 6;
				VerSpace = 3;
				HorSpace = 3;
				BlockHorSpace = 15;
				BlockVerSpace = 10;
				Offset = 5;
				TextWidth = 10;
				TextFont = new Font("Tahoma", 6);
			}
			else
			{
				BoxW = 15;
				BoxH = 10;
				VerSpace = 5;
				HorSpace = 5;
				BlockHorSpace = 30;
				BlockVerSpace = 20;
				Offset = 10;
				TextWidth = 10;
				TextFont = new Font("Tahoma", 8);
			}
			if (!color)
			{
				penR = new Pen(Color.Black, 2);
				penB = new Pen(Color.Black, .5f);
				pen = new Pen(Color.Black, .5f);
				brGreen = (SolidBrush)Brushes.Black;
				brRed = Brushes.Black;
				brFont = Brushes.Black;
			}
		}

		Pen penR = new Pen(Color.Red, 2);
		Pen penB = new Pen(Color.Blue, 1);
		Pen pen = new Pen(Color.Black, 1);
		SolidBrush brGreen = new SolidBrush(Color.FromArgb(30, 255, 30));
		Brush brRed = Brushes.Red;
		Brush brFont = Brushes.Brown;
		int BoxW;
		int BoxH;
		int VerSpace;
		int HorSpace;
		int BlockHorSpace;
		int BlockVerSpace;
		int Offset;
		int TextWidth;
		int ChoiceCount;
		int ColumnCount;
		int QuestionCount;
		Font TextFont;
		bool color;
		public Bitmap GetBitmap(string Answers, string Key)
		{
			Size size = GetSize();
			Bitmap bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			Draw(g, new Rectangle(0, 0, size.Width, size.Height), Answers, Key);
			g.Dispose();
			return bmp;
		}
		public Size GetBlockSize()
		{
			int BlockWidth = (HorSpace + BoxW) * ChoiceCount + TextWidth - HorSpace;
			int BlockHeight = 10 * (BoxH + VerSpace) - VerSpace;

			return new Size(BlockWidth, BlockHeight);
		}
		public Size GetSize()
		{
			int EyeCount = QuestionCount / ColumnCount;
			int nBlock = EyeCount / 10;

			Size bs = GetBlockSize();
			int W = (bs.Width + BlockHorSpace) * ColumnCount - BlockHorSpace + 2 * Offset;
			int H = (bs.Height + BlockVerSpace) * nBlock - BlockVerSpace + 2 * Offset;

			return new Size(W, H);
		}
		public void Draw(Graphics g, Rectangle r, string Answers, string Key)
		{
			int EyeCount = QuestionCount / ColumnCount;
			int nBlock = EyeCount / 10;
			int Left = r.Left + Offset;

			Size bs = GetBlockSize();
			for (int i = 0; i < ColumnCount; i++)
			{
				int Top;
				Top = r.Top + Offset;
				for (int k = 0; k < nBlock; k++)
				{
					int Question;
					Question = (i * EyeCount) + k * 10;
					DrawBlock(g, Answers, Key, Top, Left, Question, ChoiceCount);
					Top += bs.Height + BlockVerSpace;
				}
				Left += (bs.Width + BlockHorSpace);
			}
		}
		private void DrawBlock(Graphics g, string Answers, string Key, int Top, int Left, int StartNumber, int choiceCount)
		{

			for(int i = 0 ; i < 10 ; i++)
			{
				int Question = i + StartNumber;
				char answer;
				answer = (Answers.Length > Question ? Answers[Question] : '0');
				char key;
				key = (Key.Length > Question ? Key[Question] : '0');
				for(int j = 0 ; j < choiceCount ; j++)
				{
					if(key == '*' || answer == '*')
					{
						g.FillEllipse(Brushes.White, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						g.DrawEllipse(pen, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						g.DrawLine(penR, Left + TextWidth, Top + (BoxH / 2), Left + TextWidth + choiceCount * (BoxW + HorSpace) - HorSpace, Top + (BoxH / 2));
					}
					else if(answer == '0')
					{
						g.FillEllipse(Brushes.White, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						g.DrawEllipse(penB, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
					}
					else if(key != '0' && key != answer)
					{
						g.FillEllipse(Brushes.White, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						if (answer - 49 == j)
							g.FillEllipse(brRed, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						g.DrawEllipse(pen, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
					}
					else
					{
						g.FillEllipse(Brushes.White, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						if (answer - 49 == j)
							g.FillEllipse(brGreen, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
						g.DrawEllipse(pen, Left + TextWidth + j * (BoxW + HorSpace), Top, BoxW, BoxH);
					}

                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Far;
                    g.DrawString((i + StartNumber + 1).ToString(), TextFont, brFont, Left + TextWidth - 1, Top - 2, format);
				}
				if (key != '*' && key != '0')
				{
					int left = Left + TextWidth + (key - 49)*(BoxW + HorSpace) + 1;
					int top = (Top - 1);
					float zoom = BoxW / 18f;

					PointF[] points = new PointF[6];
					points[0] = new PointF(3, 5);
					points[1] = new PointF(6, 9);
					points[2] = new PointF(13, 0);
					points[3] = new PointF(15, 4);
					points[4] = new PointF(6, 14);
					points[5] = new PointF(0, 9);
					for (int l = 0; l < points.Length; l++ )
					{
						points[l].X *= zoom;
						points[l].Y *= zoom;

						points[l].X += left;
						points[l].Y += top;
					}
					GraphicsPath path = new GraphicsPath();
					path.AddPolygon(points);
					g.FillPath(color ? Brushes.Yellow : Brushes.Green, path);
					g.DrawPath(new Pen(Color.Green, .5f), path);
					//g.DrawImage(image, left, top, image.Width, image.Height);
				}
				Top += (BoxH + VerSpace);
			}
		}
	}
}
