namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArtifactModel
    {
        public int Id_Map { get; set; } // Unikátní identifikátor boxu
        public int Id_ObjektType { get; set; } // 12 Artefakt
        [Key]
        public int Id_Artifact { get; set; } // Unikátní identifikátor boxu
        public int Id_ArtifactType { get; set; } // Unikátní identifikátor boxu

        // Pozice

        public int Id_Position { get; set; }
        public int Id_ArtifactConfig { get; set; }
        public int Id_Cargo { get; set; }


        public MapPositionModel Position { get; set; }
        public ArtifactConfigModel ArtifactConfig { get; set; }

        public StaticParametersModel StaticParameters { get; set; }
        public CargoModel Cargo { get; set; }



        public ArtifactModel()

        {

        }
    }

    public enum ArtifactType
    {
        AncientRelic, // Starověká relikvie
        AdvancedTechnology, // Pokročilá technologie
        AlienArtifact, // Mimozemský artefakt
        MysticalItem // Mystický předmět
    }
}
