using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class PaysheetForm : Form
    {
        SalaryForm salaryForm = new SalaryForm();
        PaymentDetails details = new PaymentDetails();
        connectionSql connectionManager = new connectionSql();
        public PaysheetForm()
        {
            InitializeComponent();
        }

        private void PaysheetForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT s.employee_id, e.full_name, s.basic_salary, s.worked_dates, s.ot_rate, s.ot_hours, s.attendance_allowance, s.production_allowance, s.advance_amount, s.net_salary, e.profile_pic FROM salary AS s INNER JOIN employee AS e ON s.employee_id = e.employee_id WHERE s.employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            string employeeId = salaryForm.empId; ;

            string empId = details.getPaymentDetailsForEmployee(employeeId).EmployeeId;
            string fullName = details.getPaymentDetailsForEmployee(employeeId).FullName;
            string basicSalary = details.getPaymentDetailsForEmployee(employeeId).BasicSalary;
            string workeDates = details.getPaymentDetailsForEmployee(employeeId).WorkedDates;
            string otRate = details.getPaymentDetailsForEmployee(employeeId).OtRate;
            string otHours = details.getPaymentDetailsForEmployee(employeeId).OtHours;
            string attAllowance = details.getPaymentDetailsForEmployee(employeeId).AttendanceAllowance;
            string proAllowance = details.getPaymentDetailsForEmployee(employeeId).ProductionAllowance;
            string advance = details.getPaymentDetailsForEmployee(employeeId).AdvanceAmount;
            string netSalary = details.getPaymentDetailsForEmployee(employeeId).NetSalary;

            this.sheetEmployeeIdTxt.Text = empId;
            this.sheetFullNameTxt.Text = fullName;
            this.sheetBasicSalaryTxt.Text = basicSalary;
            this.sheetWorkedDatesTxt.Text = workeDates;
            this.sheetOtRateTxt.Text  = otRate;
            this.sheetOtHoursTxt.Text = otHours;
            this.sheetAttendanceAllowanceTxt.Text = attAllowance;
            this.sheetProductionAllowanceTxt.Text = proAllowance;
            this.sheetAdvanceAmountTxt.Text = advance;
            this.sheetNetSalaryTxt.Text = netSalary;
        }

    }
}
