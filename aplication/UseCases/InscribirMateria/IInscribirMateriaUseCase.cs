﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.InscribirMateria;

public interface IInscribirMateriaUseCase
{
    Task EjecutarAsync(InscribirMateriaCommand comando);
}
