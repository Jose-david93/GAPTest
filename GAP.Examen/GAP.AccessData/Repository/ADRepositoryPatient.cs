using GAP.AccessData.Contract;
using GAP.Transversal.Models;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAP.AccessData.Repository
{
    public class ADRepositoryPatient : ADRepository<Patients>, IRepositoryPatient
    {
        public Patients FindByDni(Patients patients)
        {
            Patients result = Insight.ADInsight.DefaultCnn.QuerySql<Patients>("SELECT Id, Dni, FirstName, LastName, Status " +
                "FROM Patients " +
                "WHERE Dni = @Dni ", new {Dni = patients.Dni}).FirstOrDefault();

            if (result == null)
                return default;
            return result;
        }
    }
}
