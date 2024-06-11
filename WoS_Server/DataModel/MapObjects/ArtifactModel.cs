namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArtifactModel
    {
        /// <summary>
        /// Typ artefaktu.
        /// </summary>
        public ArtifactType ArtifactType { get; set; }

        /// <summary>
        /// Konstruktor pro ArtifactModel.
        /// </summary>
        /// <param name="idGlobal">Jedinečná identifikace objektu.</param>
        /// <param name="idUser">Identifikace uživatele, pod kterého objekt spadá.</param>
        /// <param name="spawnPlace">Místo, kde se objekt objevil ve 3D prostoru.</param>
        /// <param name="width">Šířka objektu (X-osa).</param>
        /// <param name="height">Výška objektu (Y-osa).</param>
        /// <param name="depth">Hloubka objektu (Z-osa).</param>
        /// <param name="artifactType">Typ artefaktu.</param>
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
