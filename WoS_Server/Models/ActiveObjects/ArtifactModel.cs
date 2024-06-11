namespace WoS_Server.Models.ActiveObjects
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using WoS_Server.Models;

    public class ArtifactModel : Base_Module
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
        public ArtifactModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, ArtifactType artifactType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            Id_Global = idGlobal;
            Id_User = idUser;
            SpawnPlace = spawnPlace;
            Position = spawnPlace;
            PositionOnMap = new Vector2(Position.X, Position.Y);
            TargetPosition = PositionOnMap;
            Rotation = 0;
            Width = width;
            Height = height;
            Depth = depth;
            ArtifactType = artifactType;
            CanBeDestroyed = false;
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
