using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    public class MaterialUsed
    {
        public int Index { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Equipment
    {
        public int Index { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class EquipmentResponse
    {
        public int Id { get; set; }
        public string EquipmentDescription { get; set; }
        public int Order { get; set; }
        public object Created { get; set; }
        public string CreatedBy { get; set; }
        public object Modified { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class MaterialResponse
    {
        public int Id { get; set; }
        public string MaterialDescription { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Price { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
    }


    /// <summary>
    /// Material List
    /// </summary>
    public class BindMaterial
    {

        public List<MaterialUsed> materialUsed = new List<MaterialUsed>()
        {
           new MaterialUsed()
           {
               Index=0,
               Id="0",
               Name="Select Material Used"
           },
           new MaterialUsed()
           {
               Index=1,
               Id="1",
               Name="--Type Material Used--"
           },
            new MaterialUsed()
           {
                Index=2,
               Id="2",
               Name="409 Cleaner"
           },
             new MaterialUsed()
           {
                 Index=3,
               Id="3",
               Name="Bubble Wrap - 4 x 300"
           },
              new MaterialUsed()
           {
                  Index=4,
               Id="4",
               Name="Bubble Wrap - 4 x 300"
           },
               new MaterialUsed()
           {
                   Index=5,
               Id="5",
               Name="Carpet"

           },
                new MaterialUsed()
           {
                    Index=6,
               Id="6",
               Name="Carpet Padding"
           },
                 new MaterialUsed()
           {
                     Index=7,
               Id="7",
               Name="Counter - 18 x 26"
           },
                 new MaterialUsed()
                 {
                     Index=8,
                     Id="8",
                     Name="Counter(18 x 18)"
                 },
                  new MaterialUsed()
           {
                     Index=9,
               Id="9",
               Name="Double Face Tape - 25 YD"
           },
        };

    }

    /// <summary>
    /// Equipment List
    /// </summary>
    public class BindEquipment
    {

        public List<Equipment> EquipmentUsed = new List<Equipment>()
        {
           new Equipment()
           {
               Index=0,
               Id="0",
               Name="Select Equipment"
           },
           new Equipment()
           {
               Index=1,
               Id="1",
               Name="--Type Equipment--"
           },

           new Equipment()
           {
              Index=2,
               Id="2",
               Name="16' Ladder"
           },
             new Equipment()
           {
              Index=3,
              Id="3",
              Name="12' Ladder"
           },
              new Equipment()
           {
               Index=4,
               Id="4",
               Name="10' Ladder"
           },
               new Equipment()
           {
               Index=5,
               Id="5",
               Name="8' Ladder"

           },
             new Equipment()
           {
               Index=6,
               Id="6",
               Name="Steamer"
           },
                new Equipment()
           {
               Index=7,
               Id="7",
               Name="14' Ladders"
           },
                new Equipment()
                {
               Index=8,
               Id="8",
               Name="4' Ladders"
           },
                 new Equipment()
                {
               Index=9,
               Id="9",
               Name="6' Ladders"
           },
                 new Equipment()
           {
               Index=10,
               Id="10",
               Name="Dollies"
           },
             new Equipment()
           {
               Index=11,
               Id="11",
               Name="J Bar"
           },
               new Equipment()
           {
               Index=12,
               Id="12",
               Name="Genie Lift"
           },

               new Equipment()
           {
               Index=13,
               Id="13",
               Name="4' Ladder"
           },
               new Equipment()
           {
               Index=14,
               Id="14",
               Name="Banding Sets"
           },
               new Equipment()
                {
                      Index=15,
               Id="15",
               Name="Hole Saw Kit"
           },
        };

    }
}
