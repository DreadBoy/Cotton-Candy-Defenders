using System;
using System.Collections.Generic;
public class PlayerProgress
{
    public class TowerProgress
    {
        public class Progress
        {
            public Boolean unlocked = false;
            public Boolean upgraded = false;
            public Boolean left = false;
            public Boolean right = false;
        }
        public Dictionary<TowerType, Progress> progress = new Dictionary<TowerType, Progress>();

        public TowerProgress()
        {
            progress.Add(TowerType.basic, new Progress());
            progress.Add(TowerType.slow, new Progress());
            progress.Add(TowerType.stun, new Progress());
            progress.Add(TowerType.pierce, new Progress());
            progress.Add(TowerType.poison, new Progress());
            progress.Add(TowerType.fear, new Progress());
            progress.Add(TowerType.charm, new Progress());
            progress[TowerType.basic].unlocked = true;
        }
    }
    public class Gold
    {
        private const Int32 Max = 10000;
        private const Int32 Min = 0;
        private Int32 _gold = 600;
        private Int32 _diamants = 0;
        public Int32 gold
        {
            get { return _gold; }
            private set { _gold = value; }
        }
        public Int32 diamants
        {
            get { return _diamants; }
            private set { _diamants = value; }
        }
        public Boolean Earn(Int32 amount)
        {
            if (_gold + amount > Max)
                return false;
            else
            {
                _gold += amount;
                return true;
            }
        }
        public Boolean Spend(Int32 amount)
        {
            if (_gold - amount < 0)
                return false;
            else
            {
                _gold -= amount;
                return true;
            }
        }

    }

    public static Gold gold = new Gold();
    public static TowerProgress towerProgress = new TowerProgress();
    public static Int32 level = 2;
    public static Int32 levelMax = 4;

}