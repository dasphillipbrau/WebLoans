using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using WebLoans.app.Classes;

namespace WebLoans.app
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculateLoan_Click(object sender, EventArgs e)
        {
            double remainder;
            int term, payments;

            if (double.TryParse(txtAmount.Text, out remainder))
            {
                if (int.TryParse(txtTerm.Text, out term))
                {
                    Loan loan = new Loan(Convert.ToDouble(txtAmount.Text), Convert.ToDouble(txtInterest.Text), Convert.ToInt32(txtTerm.Text), Convert.ToInt32(ddlCurrency.SelectedValue));

                    loan.InsertLoan();

                    lblMessage.Text = "Monthly Payment: " + Convert.ToString(loan.CalculatePayment());

                    DataTable dt = new DataTable();
                    DataColumn dc = new DataColumn();

                    if(dt.Columns.Count == 0)
                    {
                        dt.Columns.Add("Payment", typeof(string));
                        dt.Columns.Add("Collateral", typeof(string));
                        dt.Columns.Add("Interest", typeof(string));
                        dt.Columns.Add("Remainder", typeof(string));
                    }

                    payments = term * 12;

                    for(int i = 1; i <= payments; i++)
                    {
                        double collateral;

                        collateral = loan.CalculatePayment() - loan.CalculateInterest(remainder);
                        remainder -= collateral;

                        DataRow newRow = dt.NewRow();

                        newRow[0] = i.ToString();
                        newRow[1] = collateral;
                        newRow[2] = loan.CalculateInterest(remainder);
                        newRow[3] = remainder;

                        dt.Rows.Add(newRow);
                    }

                    grdLoanData.DataSource = dt;
                    grdLoanData.DataBind();
                }
                else
                {
                    lblMessage.Text = "Set a numeric term.";
                }
            }
            else
            {
                lblMessage.Text = "Set a numeric amount.";
            }

        }
    }
}