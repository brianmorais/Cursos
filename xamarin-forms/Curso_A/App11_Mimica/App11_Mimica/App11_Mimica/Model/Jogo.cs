﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App11_Mimica.Model
{
    public class Jogo
    {
        public Grupo Grupo1 { get; set; }
        public Grupo Grupo2 { get; set; }
        public string Nivel { get; set; }
        public short TempoPalavra { get; set; }
        public short Rodadas { get; set; }
        public int NivelNumerico { get; set; }
    }
}
