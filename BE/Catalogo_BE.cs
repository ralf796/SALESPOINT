﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Catalogo_BE
    {
        public int MTIPO { get; set; }
        public int ID_VENTA { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public int STOCK { get; set; }
        public string PATH_IMG { get; set; }
    }
}