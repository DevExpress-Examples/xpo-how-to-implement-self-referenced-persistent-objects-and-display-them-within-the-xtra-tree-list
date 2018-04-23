using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Data.Filtering;

namespace SelfReferenced {
    public partial class Form1 : Form {
        public Form1() {
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(AutoCreateOption.DatabaseAndSchema);
            CreateDefaultData();

            InitializeComponent();
        }

        void CreateDefaultData() {
            using(UnitOfWork uow = new UnitOfWork()) {
                if(uow.FindObject<Employee>(null) != null) return;

                Employee AndrewFuller = new Employee(uow);
                AndrewFuller.FullName = "Andrew Fuller";
                AndrewFuller.Title = "Vice President, Sales";

                Employee NancyDavolio = new Employee(uow);
                NancyDavolio.FullName = "Nancy Davolio";
                NancyDavolio.Title = "Sales Representative";
                NancyDavolio.Manager = AndrewFuller;

                Employee JanetLeverling = new Employee(uow);
                JanetLeverling.FullName = "Janet Leverling";
                JanetLeverling.Title = "Sales Representative";
                JanetLeverling.Manager = AndrewFuller;

                Employee MargaretPeacock = new Employee(uow);
                MargaretPeacock.FullName = "Margaret Peacock";
                MargaretPeacock.Title = "Sales Representative";
                MargaretPeacock.Manager = AndrewFuller;

                Employee StevenBuchanan = new Employee(uow);
                StevenBuchanan.FullName = "Steven Buchanan";
                StevenBuchanan.Title = "Sales Manager";
                StevenBuchanan.Manager = AndrewFuller;

                Employee MichaelSuyama = new Employee(uow);
                MichaelSuyama.FullName = "Michael Suyama";
                MichaelSuyama.Title = "Sales Representative";
                MichaelSuyama.Manager = StevenBuchanan;

                Employee RobertKing = new Employee(uow);
                RobertKing.FullName = "Robert King";
                RobertKing.Title = "Sales Representative";
                RobertKing.Manager = StevenBuchanan;

                Employee LauraCallahan = new Employee(uow);
                LauraCallahan.FullName = "Laura Callahan";
                LauraCallahan.Title = "Inside Sales Coordinator";
                LauraCallahan.Manager = AndrewFuller;

                Employee AnneDodsworth = new Employee(uow);
                AnneDodsworth.FullName = "Anne Dodsworth";
                AnneDodsworth.Title = "Sales Representative";
                AnneDodsworth.Manager = StevenBuchanan;

                uow.CommitChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            treeList1.KeyFieldName = "This";
            treeList1.ParentFieldName = "Manager!";
            treeList1.RootValue = null;
            treeList1.DataSource = xpCollection1;

            treeList1.ExpandAll();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if(unitOfWork1.InTransaction)
                unitOfWork1.CommitChanges();
        }
    }
}