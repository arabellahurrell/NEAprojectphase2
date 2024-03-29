﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TuesPechkin;

namespace NEAproject.Models
{
    public class fileoperation
    {
        public fileoperation(string inputroot)
        {
            root = inputroot;
        }
        public static string root
        {
            get;
            set;
        }
        public string createuserfolder(string userid)
        {
            string path = root + userid;
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                Directory.CreateDirectory(path);
                return path;
            }
        }
        //public bool savefile(string fullfolderpath, string filename)
        //{
        //    var directory = new DirectoryInfo(fullfolderpath);
            //Code to store the file deposited from page
            //File.SaveAs
        //}
        public static void converttopdf(string filename)
        {
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = { PaperSize = PaperKind.A4, Margins = { All = 1.37, Unit = Unit.Centimeters }, OutputFormat = GlobalSettings.DocumentOutputFormat.PDF },
                Objects = { new ObjectSettings { HtmlText = @"<!DOCTYPE html><html><head><title>Test</title></head><body>test#test3#test1</body></html>" } }
            };
            IConverter converter = new StandardConverter(new PdfToolset(new WinAnyCPUEmbeddedDeployment((new TempFolderDeployment()))));
            var pdf = converter.Convert(document);
            File.WriteAllBytes(filename, pdf);
        }
        public static void converttopdf2(string filename, string rootpath, string userid, string content )
        {
            userid = userid.Replace("@", " ").Replace(".", " ");
            if(!Directory.Exists(rootpath + @"\" + userid))
            {
                Directory.CreateDirectory(rootpath + @"\"+ userid);
            }
            string FullfindPath = rootpath + @"\" + userid + @"\" + filename;
            if (!File.Exists(FullfindPath))
                //if file exist then delete otherwise dont do anything
            {

            }
            else
            {
                File.Delete(FullfindPath);
            }
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = { PaperSize = PaperKind.A4, Margins = { All = 1.37, Unit = Unit.Centimeters }, OutputFormat = GlobalSettings.DocumentOutputFormat.PDF },
                Objects = { new ObjectSettings { HtmlText = content } }
            };
            IConverter converter = new StandardConverter(new PdfToolset(new WinAnyCPUEmbeddedDeployment((new TempFolderDeployment()))));
            var pdf = converter.Convert(document);
            File.WriteAllBytes(FullfindPath, pdf);
        }

    }
}
