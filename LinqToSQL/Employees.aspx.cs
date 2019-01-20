using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqToSQL
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // GetData();

        }

        private void GetData()
        {
            var dataContext = new SampleDataContext();
            //var maleEmployees = from employee in dataContext.DepartmentEmployees
            //                    where employee.Gender == "Male"
            //                    orderby employee.EmployeeId descending
            //                    select employee;

           // var maleEmployees = dataContext.DepartmentEmployees.Where(emp => emp.Gender == "Male").OrderBy(emp => emp.EmployeeId);
            GridView1.DataSource = dataContext.DepartmentEmployees;
            GridView1.DataBind();
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (var dbContext=new SampleDataContext())
            {
                var employee = new DepartmentEmployee()
                {
                    EmployeeId = 100,
                    Name = "Sikandar Sultan",
                    Gender = "Male",
                    City = "Patna",
                    DepartmentId = 3
                };
                dbContext.DepartmentEmployees.InsertOnSubmit(employee);
                dbContext.SubmitChanges();

            }
            GetData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var dbContext = new SampleDataContext())
            {
                var employee = (from Deptemployee in dbContext.DepartmentEmployees
                                where Deptemployee.Name == "Sikandar Sultan" select Deptemployee).SingleOrDefault();

                employee.Name = "Sikandaar Mahaan";
                
                dbContext.SubmitChanges();

            }
            GetData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (var dbContext = new SampleDataContext())
            {
                var employee = (from Deptemployee in dbContext.DepartmentEmployees
                                where Deptemployee.Name == "Sikandaar Mahaan"
                                select Deptemployee).SingleOrDefault();

                dbContext.DepartmentEmployees.DeleteOnSubmit(employee);

                dbContext.SubmitChanges();

            }
            GetData();
        }
    }
}