﻿namespace CourseWork_Algorithms_Data_Structures
{
    public class ElementSecondaryStructure
    {
        public Airplane Airplane { get; set; }

        public ElementSecondaryStructure Next { get; set; }

        public ElementSecondaryStructure(Airplane airplane)
        {
            Airplane = airplane;
        }
    }
}
