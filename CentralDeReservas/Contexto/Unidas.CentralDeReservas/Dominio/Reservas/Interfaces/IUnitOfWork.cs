﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Unidas.CentralDeReservas.Dominio.Reservas.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
