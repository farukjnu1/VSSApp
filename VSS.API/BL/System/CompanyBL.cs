using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.BL.System
{
    public class CompanyBL
    {
        ModelVssDb _vssDb = null;
        public CompanyVM Get(int CompanyId)
        {
            _vssDb = new ModelVssDb();
            var oCompany = _vssDb.Companies.Where(y => y.CompanyId == CompanyId)
                .Select(x => new CompanyVM
                {
                    Address = x.Address,
                    Bay = x.Bay,
                    CompanyCode = x.CompanyCode,
                    CompanyName = x.CompanyName,
                    CompanyId = x.CompanyId,
                    DateFormat = x.DateFormat,
                    DecimalPlace = x.DecimalPlace,
                    Description = x.Description,
                    Email = x.Email,
                    IsActive = x.IsActive,
                    Phone = x.Phone,
                    Vat = x.Vat,
                    Website = x.Website,
                    Logos = (from z in _vssDb.CompanyLogoes
                             where z.CompanyId == x.CompanyId
                             select new CompanyLogoVM()
                             {
                                 CompanyId = x.CompanyId,
                                 LogoId = z.LogoId,
                                 LogoUrl = z.LogoUrl,
                                 Name = z.Name   
                             }).ToList()
                }).FirstOrDefault();
            return oCompany;
        }
    }
}