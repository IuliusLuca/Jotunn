﻿using System.Collections.Generic;
using System.Linq;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn.Utils
{
    /// <summary>
    ///     Utility class to query metadata about loaded mods and their added content
    /// </summary>
    public static class ModRegistry
    {
        /// <summary>
        ///     Get all loaded mod's metadata
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ModInfo> GetMods()
        {
            foreach (var mod in BepInExUtils.GetDependentPlugins().Values.Select(mod => mod.Info.Metadata))
            {
                yield return new ModInfo()
                {
                    GUID = mod.GUID,
                    Name = mod.Name,
                    Version = mod.Version
                };
            }
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomPrefab"/>s
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomPrefab> GetPrefabs()
        {
            return PrefabManager.Instance.Prefabs;
        }

        /// <summary>
        ///     Get all added <see cref="CustomPrefab"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomPrefab> GetPrefabs(string modGuid)
        {
            return PrefabManager.Instance.Prefabs.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomItem"/>s
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomItem> GetItems()
        {
            return ItemManager.Instance.Items.ToList();
        }

        /// <summary>
        ///     Get all added <see cref="CustomItem"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomItem> GetItems(string modGuid)
        {
            return ItemManager.Instance.Items.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomRecipe"/>s
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomRecipe> GetRecipes()
        {
            return ItemManager.Instance.Recipes.ToList();
        }

        /// <summary>
        ///     Get all added <see cref="CustomRecipe"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomRecipe> GetRecipes(string modGuid)
        {
            return ItemManager.Instance.Recipes.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomItemConversion"/>s of a mod by GUID
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomItemConversion> GetItemConversions()
        {
            return ItemManager.Instance.ItemConversions.ToList();
        }

        /// <summary>
        ///     Get all added <see cref="CustomItemConversion"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomItemConversion> GetItemConversions(string modGuid)
        {
            return ItemManager.Instance.ItemConversions.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomStatusEffect"/>s
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomStatusEffect> GetStatusEffects()
        {
            return ItemManager.Instance.StatusEffects.ToList();
        }

        /// <summary>
        ///     Get all added <see cref="CustomStatusEffect"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomStatusEffect> GetStatusEffects(string modGuid)
        {
            return ItemManager.Instance.StatusEffects.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomPieceTable"/>s
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomPieceTable> GetPieceTables()
        {
            return PieceManager.Instance.PieceTables.ToList();
        }

        /// <summary>
        ///     Get all added <see cref="CustomPieceTable"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomPieceTable> GetPieceTables(string modGuid)
        {
            return PieceManager.Instance.PieceTables.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }
        
        /// <summary>
        ///     Get all added <see cref="CustomPiece"/>s
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomPiece> GetPieces()
        {
            return PieceManager.Instance.Pieces.ToList();
        }
        /// <summary>
        ///     Get all added <see cref="CustomPiece"/>s of a mod by GUID
        /// </summary>
        /// <param name="modGuid">GUID of the mod</param>
        /// <returns></returns>
        public static IEnumerable<CustomPiece> GetPieces(string modGuid)
        {
            return PieceManager.Instance.Pieces.Where(x => x.SourceMod.GUID.Equals(modGuid));
        }

        /// <summary>
        ///     Model class holding metadata of Jötunn mods.
        /// </summary>
        public class ModInfo
        {
            /// <summary>
            ///     The mod GUID
            /// </summary>
            public string GUID { get; internal set; }

            /// <summary>
            ///     Human readable name
            /// </summary>
            public string Name { get; internal set; }

            /// <summary>
            ///     Current version
            /// </summary>
            public System.Version Version { get; internal set; }
            
            /// <summary>
            ///     Custom prefabs added by that mod
            /// </summary>
            public IEnumerable<CustomPrefab> Prefabs
            {
                get
                {
                    return GetPrefabs(GUID);
                }
            }

            /// <summary>
            ///     Custom items added by that mod
            /// </summary>
            public IEnumerable<CustomItem> Items
            {
                get
                {
                    return GetItems(GUID);
                }
            }
            
            /// <summary>
            ///     Custom recipes added by that mod
            /// </summary>
            public IEnumerable<CustomRecipe> Recipes
            {
                get
                {
                    return GetRecipes(GUID);
                }
            }
            
            /// <summary>
            ///     Custom item conversions added by that mod
            /// </summary>
            public IEnumerable<CustomItemConversion> ItemConversions
            {
                get
                {
                    return GetItemConversions(GUID);
                }
            }

            /// <summary>
            ///     Custom status effects added by that mod
            /// </summary>
            public IEnumerable<CustomStatusEffect> StatusEffects
            {
                get
                {
                    return GetStatusEffects(GUID);
                }
            }

            /// <summary>
            ///     Custom piece tables added by that mod
            /// </summary>
            public IEnumerable<CustomPieceTable> PieceTables
            {
                get
                {
                    return GetPieceTables(GUID);
                }
            }

            /// <summary>
            ///     Custom pieces added by that mod
            /// </summary>
            public IEnumerable<CustomPiece> Pieces
            {
                get
                {
                    return GetPieces(GUID);
                }
            }
        }
    }
}