using System;
using System.Collections.Generic;
using System.Data;

namespace KartSkills.Models
{
    public class Gender
    {
        public string IdGender { get; set; }
        public string GenderName { get; set; }

        public Gender(DataRow data)
        {
            IdGender = data["Id_Gender"] as string;
            GenderName = data["Gender_Name"] as string;
        }

        public Gender()
        {
        }

        public new static bool Equals(object objA, object objB)
        {
            if (objA.GetType() == objB.GetType() && objB.GetType() == typeof(Gender))
                return ((Gender)objA).IdGender == ((Gender)objB).IdGender;
            return false;
        }

        public override bool Equals(object? objA)
        {
            if (objA == null)
                return false;
            return Gender.Equals(this, objA);
        }
    }
}