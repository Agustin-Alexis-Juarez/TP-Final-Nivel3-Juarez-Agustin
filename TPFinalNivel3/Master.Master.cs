﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public bool IniciarSesion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarSesion = false;
        }
    }
}