﻿using MyAcademy_DesignPattern_ChainOfResponsibility.ChainOfResponsibility.Models;
using MyAcademy_DesignPattern_ChainOfResponsibility.DAL.Context;
using MyAcademy_DesignPattern_ChainOfResponsibility.DAL.Entities;
using MyAcademy_DesignPattern_ChainOfResponsibility.Models;

namespace MyAcademy_DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainofRespContext context = new ChainofRespContext();

            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar-Berkan Bayraktar";
                customerProcess.Description = "Müşterinin talep ettiği kredi tuttarı ödenmiştir.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }

            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar-Berkan Bayraktar";
                customerProcess.Description = "Müşterinin talep ettiği kredi tuttar tarafınca ödenemediği için işlem şube müdür yardımcısına aktarılmıştır";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
