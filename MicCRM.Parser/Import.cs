using MicCRM.Info.Models;
using MicCRM.Logic.Controllers;
using MicCRM.Logic.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MicCRM.Parser
{
    public class Import
    {

        private Excel.Application xlApp;
        private Excel.Workbook xlWorkbook;
        private Excel._Worksheet xlWorksheet;
        private Excel.Range xlRange;
        public string ExcelFilePath { get; set; }
        public Import(bool IsFirstTime)
        {
            if (IsFirstTime)
            {
                this.ExcelFilePath = GetFilePath();
                xlApp = new Excel.Application();
                if (!string.IsNullOrEmpty(this.ExcelFilePath))
                {
                    xlWorkbook = xlApp.Workbooks.Open(this.ExcelFilePath);
                    xlWorksheet = xlWorkbook.Sheets[1];
                    xlRange = xlWorksheet.UsedRange;
                } 
            }  
        } 
        private string GetFilePath()
        {
            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                path = openFileDialog.FileName;

            }
            return path;
        }
        public void AddToDB(IEnumerable<ApplicantViewModel> applicants)
        {
            ApplicantController applicantController = new ApplicantController();
            applicantController.AddApplicants(applicants.ToList());
        }
        public async Task<List<ApplicantViewModel>> ReadFromExcel(string TechName)
        {
            List<ApplicantViewModel> list = new List<ApplicantViewModel>();
            try
            {
                for (int i = 2; i <= this.xlRange.Rows.Count; i++)
                {
                    ApplicantViewModel applicant = (ApplicantViewModel)Activator.CreateInstance(typeof(ApplicantViewModel));
                    applicant.FirstName = xlRange.Cells[i, 1].Value2.ToString();
                    applicant.LastName = xlRange.Cells[i, 2].Value2.ToString();
                    applicant.Email = xlRange.Cells[i, 3].Value2.ToString();
                    applicant.Phone1 = xlRange.Cells[i, 4].Value2.ToString(); 
                    string sDate = xlRange.Cells[i, 9].Value2.ToString(); 
                    double date = double.Parse(sDate); 
                    var dateTime = DateTime.FromOADate(date).ToShortDateString();
                    applicant.Date = Helper.GetDate(dateTime);
                    applicant.Description =  xlRange.Cells[i, 8].Value2.ToString();
                    TechnologyController techctrl = new TechnologyController();
                    applicant.Technology =  await techctrl.GetByNameAsync(TechName); 
                    list.Add(applicant); 
                } 
            } 
            finally
            {
                this.xlWorkbook.Close();
            }
            return list;
        } 

    } 
}
