using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Fundamental
{
    public partial class frmLessonEquivalenceDetail : rRadDetailForm
    {
        public frmLessonEquivalenceDetail(LessonEquivalence equivalence)
        {
            InitializeComponent();

            SetProcessingObject(equivalence);

            if (equivalence.EquivalentLesson != null)
            {
                departmentSelector1.Department = equivalence.EquivalentLesson.Major.Department;
                majorSelector1.Major = equivalence.EquivalentLesson.Major;
                lessonSelector1.Lesson = equivalence.EquivalentLesson;
            }
        }

        #region Overrides of rRadDetailForm

        protected override void AfterBindToObject()
        {
            LessonEquivalence lessonEquivalence = GetProcessingObject<LessonEquivalence>();
            lessonEquivalence.EquivalentLesson = lessonSelector1.Lesson;
        }

        #endregion
    }
}
