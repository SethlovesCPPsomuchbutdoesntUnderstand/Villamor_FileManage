using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Villamor_FileManage
{
    public partial class FileUploadAct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)

                try
                {
                    FileUpload1.SaveAs(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\" + FileUpload1.FileName);
                    Label1.Text = "File Uploaded Successfully!" + " with " + FileUpload1.PostedFile.ContentLength + " ab.";
                    FileUpload2.SaveAs(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\" + FileUpload2.FileName);
                    Label1.Text = "File Uploaded Successfully!" + " with " + FileUpload2.PostedFile.ContentLength + " ab.";
                    FileUpload3.SaveAs(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\" + FileUpload3.FileName);
                    Label1.Text = "File Uploaded Successfully!" + " with " + FileUpload3.PostedFile.ContentLength + " ab.";
                    FileUpload4.SaveAs(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\" + FileUpload4.FileName);
                    Label1.Text = "File Uploaded Successfully!" + " with " + FileUpload4.PostedFile.ContentLength + " ab.";
                    FileUpload5.SaveAs(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\" + FileUpload5.FileName);
                    Label1.Text = "File Uploaded Successfully!" + " with " + FileUpload5.PostedFile.ContentLength + " ab.";

                }
                catch
                {
                    Label1.Text = "File Not Upload.";
                }
            else
            {
                Label1.Text = "Error! please select File to Upload.";
            }

            try
            {
                Label3.Text = File.ReadAllText(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\read.txt");
                File.WriteAllText(@"C:\Users\Renie Joshua (Wang)\OneDrive\Desktop\FileUpload\write.txt", TextBox1.Text);
                TextBox1.Text = "BasahaKo";
                Label2.Text = "File updated!";

                
            }
            catch (Exception)
            {
                Label3.Text = "Error: ";
            }
        }
    }
}