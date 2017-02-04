using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewAshAIO
{
    public partial class NotePage : UserControl
    {
        private TabPage PMyPage;
        private NoteSheets PMyForm;

        public NotePage(TabPage page, NoteSheets form) : base()
        {
            InitializeComponent();
            PMyPage = page;
            PMyForm = form;
            Sheet sheet = (Sheet)page.Tag;
            SheetText.Text = sheet.content;
            SheetTitle.Text = sheet.title;
        }
        /*void SheetText_TextChanged(object sender, EventArgs e)
        {
            Sheet sheet = (Sheet)PMyPage.Tag;
            sheet.content = SheetText.Text;
        }*/
        void SheetTextTextChanged(object sender, EventArgs e)
        {
            Sheet sheet = (Sheet)PMyPage.Tag;
            sheet.content = SheetText.Text;
        }
        /*void SheetTitle_TextChanged(object sender, EventArgs e)
        {
        	Sheet sheet = (Sheet)PMyPage.Tag;
            sheet.title = SheetTitle.Text;
            PMyForm.UpdateTitle(PMyPage);
        }*/
        void SheetTitleTextChanged(object sender, EventArgs e)
        {
        	Sheet sheet = (Sheet)PMyPage.Tag;
            sheet.title = SheetTitle.Text;
            PMyForm.UpdateTitle(PMyPage);
        }
	    /*void DelCurSheet_Click(object sender, EventArgs e)
		{
	       PMyForm.DeleteSheet(PMyPage);
		}*/
		void DelCurSheetClick(object sender, EventArgs e)
		{
			PMyForm.DeleteSheet(PMyPage);
		}
    }
}