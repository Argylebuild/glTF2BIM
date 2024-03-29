﻿using System;
using System.Numerics;
using Newtonsoft.Json;

namespace GLTF2BIM.GLTF.Extensions.BIM.Schema
{
	public abstract class Bucket
	{
		/// <summary>
		/// Simple name describing this collection. 
		/// </summary>
		[JsonProperty("name", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
		/// <summary>
		/// A more detailed description of this collection.
		/// </summary>
		[JsonProperty("description", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }
		/// <summary>
		/// All elements in this collection will display this color in the AR viewer.
		/// User may also apply colors to view in authoring software.
		/// Colors stored as RGB <= 1.0
		/// </summary>
		[JsonProperty("color", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
		public Vector3 Color { get; set; }
		/// <summary>
		/// If true, when app opens this project, everything in the collection will be visible
		/// as long as other requirements are met. (E.G. Link is on and in range)
		/// </summary>
		[JsonProperty("isVisibleAtStart", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
		public bool IsVisibleAtStart { get; set; }
		/// <summary>
		/// The minature view doesn't need to show everything in the model but only what is helpful for navigation.
		/// Core and shell, structure, floors, and walls are all recommended. 
		/// </summary>
		[JsonProperty("isIncludedInDollhouse", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
		public bool IsIncludedInDollhouse { get; set; }

		/// <summary>
		/// For visual simplicity, it is helpful for some elements to hide elements behind them.
		/// Walls, floors, Roofs and sometimes ceilings are good candidates for occlusion.
		/// </summary>
		[JsonProperty("isOccluding", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
		public bool IsOccluding { get; set; }

		/// <summary>
		/// Most small elements are only rendered when the user is close to them.
		/// Large elements that are critical for navigation should be rendered at all times.
		/// Floors or Core and Shell, for example should be set to false. 
		/// </summary>
		[JsonProperty("isProximityBased", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
		public bool IsProximityBased { get; set; } = true;


        #region ==== CTOR ====------------------

        /// <summary>
        /// Standard minimum constructor. Populates basic values and random color. 
        /// </summary>
        /// <param name="name"></param>
        public Bucket(string name)
		{
			Name = name;
			Description = "";
			Color = GetColorByString(DateTime.Now.Millisecond.ToString());
		}

		/// <summary>
		/// Full constructor to set all properties in one go.
		/// Useful for hardcoding default values.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="description"></param>
		/// <param name="color"></param>
		/// <param name="isVisibleAtStart"></param>
		/// <param name="isIncludedInDollhouse"></param>
		/// <param name="isOccluding"></param>
		/// <param name="isProximityBased"></param>
		public Bucket(string name, string description, Vector3 color, 
			bool isVisibleAtStart, bool isIncludedInDollhouse, bool isOccluding, 
			bool isProximityBased)
		{
			Name = name;
			Description = description;
			Color = color;
			IsVisibleAtStart = isVisibleAtStart;
			IsIncludedInDollhouse = isIncludedInDollhouse;
			IsOccluding = isOccluding;
			IsProximityBased = isProximityBased;
		}

		/// <summary>
		/// This constructor is only used for deserialization.
		/// </summary>
		public Bucket() { }

		#endregion -----------------/CTOR ====



		#region ==== Helper ====------------------

		/// <summary>
		/// Link colors are generated by a random color generator seeded by a given string.
		/// Use consistent string input (E.G. name or id) to get consistent color output.
		/// </summary>
		/// <param name="stringSeed"></param>
		/// <returns></returns>
		private Vector3 GetColorByString(string stringSeed)
		{
			var r = StringToRandomFloat(stringSeed + "r");
			var g = StringToRandomFloat(stringSeed + "g");
			var b = 1 - (r + g);
			Vector3 c = new Vector3(r, g, b);

			return c;
			
			//---------------local functions----------------
			float StringToRandomFloat(string input)
			{
				var seed = input.GetHashCode();
				Random rand = new Random(input.GetHashCode());
				return (float) rand.Next(0,256) / 256f;
			}
		}


		#endregion -----------------/Helper ====
        
        
	}
}