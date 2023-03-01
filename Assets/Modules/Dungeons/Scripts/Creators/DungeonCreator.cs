using Modules.Dungeons.Generator.Enums;

namespace Modules.Dungeons.Creators
{
    public class DungeonCreator
    {
        public DungeonCreator()
        { 
            //reserved
        }

        public EnumCellType[,] Create(int width, int height)
        {
            //TODO: generated with config
            var dungeon = new EnumCellType[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    dungeon[x, y] = EnumCellType.CommonFloor;

            return dungeon;
        }
    }
}
