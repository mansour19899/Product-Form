﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Form
{
    class ConvertMetricInch
    {
        public ConvertMetricInch()
        {

        }

        double _widthM;
        double _DepthM ;
        double _HeightM ;
        double _WeightM ;

        double _WidthI ;
        double _DepthI ;
        double _HeightI ;
        double _WeightI ;


        public double WidthM {
            get
            {
                return Math.Round(_widthM, 4);
            }
            set
            {
                _widthM = value;
                _WidthI = value / 2.54;
            }
        }
        public double DepthM
        {
            get
            {
                return Math.Round(_DepthM, 4);
            }
            set
            {
                _DepthM = value;
                _DepthI = value / 2.54;
            }
        }
        public double HeightM
        {
            get
            {
                return Math.Round(_HeightM, 4);
            }
            set
            {
                _HeightM = value;
                _HeightI = value / 2.54;
            }
        }
        public double WeightM
        {
            get
            {
                return Math.Round(_WeightM, 4);
            }
            set
            {
                _WeightM = value;
                _WeightI = value / 2.54;
            }
        }

        public double WidthI
        {
            get
            {
                return Math.Round(_WidthI, 4);
            }
            set
            {
                _WidthI = value;
                _widthM = value * 2.54;
            }
        }
        public double DepthI
        {
            get
            {
                return Math.Round(_DepthI, 4);
            }
            set
            {
                _DepthI = value;
                _DepthM = value * 2.54;
            }
        }
        public double HeightI
        {
            get
            {
                return Math.Round(_HeightI, 4);
            }
            set
            {
                _HeightI = value;
                _HeightM = value * 2.54;
            }
        }
        public double WeightI
        {
            get
            {
                return Math.Round(_WeightI, 4);
            }
            set
            {
                _WeightI = value;
                _WeightM = value * 2.54;
            }
        }


    }
}
