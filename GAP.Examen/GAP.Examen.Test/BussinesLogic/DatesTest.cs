using GAP.BussinesLogic.Date;
using GAP.Transversal.Models;
using GAP.Transversal.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GAP.Examen.Test.BussinesLogic
{
    [TestClass]
    public class DatesTest
    {
        private BLDate _bLDate;
        [TestInitialize]
        public void Init()
        {
            _bLDate = new BLDate();
        }
        [TestMethod]
        public void IsIdNull_CancelDate()
        {
            string Id = "";

            Response<bool> response = _bLDate.CancelDate(Id);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
            Assert.AreEqual(response.Message, "Id no permitido");
        }


        [TestMethod]
        public void IsNotCancelable_CancelDate()
        {
            //Change for recent Date.
            string Id = "3a3976e0-c27a-4318-9d3b-37083d08a8e9";

            Response<bool> response = _bLDate.CancelDate(Id);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
            Assert.AreEqual(response.Message, "La cita no se puede cancelar");
        }

        [TestMethod]
        public void IsSuccessCancelDate_CancelDate()
        {
            //Change for recent Date.
            string Id = "8B4711AB-9059-40C3-BB4B-078E0AAECDDF";

            Response<bool> response = _bLDate.CancelDate(Id);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Message, "Cita cancelada con exito");
        }

        [TestMethod]
        public void PatientHaveDate_CreateDate()
        {
            //Change for recent Date.
            Dates dates = new Dates();
            dates.Dni = "123";
            dates.FirstName = "Jose";
            dates.LastName = "Sanchez";
            dates.IdService = new Guid("DBE8DCA0-6061-4258-B1BA-31A5D629A2C3");
            dates.IdPatient = new Guid("79A5AB8D-DBB8-40A7-9B4C-A5F3050C362B");
            dates.DateService = DateTime.Parse("2019-12-1 3:50:00");
            dates.Description = "PruebaTest";
            Response<Dates> response = _bLDate.CreateDate(dates);

            Assert.IsNotNull(response);
            Assert.IsNull(response.Data);
            Assert.IsFalse(response.Success);
            Assert.AreEqual(response.Message, "El paciente ya tiene una cita");
        }

        [TestMethod]
        public void CreatedSuccess_CreateDate()
        {
            //Change for recent Date.
            Dates dates = new Dates();
            dates.Dni = "123";
            dates.FirstName = "Jose";
            dates.LastName = "Sanchez";
            dates.IdService = new Guid("DBE8DCA0-6061-4258-B1BA-31A5D629A2C3");
            dates.IdPatient = new Guid("79A5AB8D-DBB8-40A7-9B4C-A5F3050C362B");
            dates.DateService = DateTime.Parse("2019-12-2 3:50:00");
            dates.Description = "PruebaTest";
            Response<Dates> response = _bLDate.CreateDate(dates);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Message, "Cita creada con exito");
        }
    }
}
