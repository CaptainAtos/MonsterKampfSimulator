namespace MonsterKampfSimulator.Monster
{
    public class Goblin : Monster
    {
        public float CritP;
        public Goblin(string _name, float _currentHP, float _AP, float _DP, float _SP, float _CritP = 25) : base(_name, _currentHP, _AP, _DP, _SP)
        {
            CritP = _CritP;
            IsGoblin = true;
        }

        public override void Attack(float _dmg, Monster _defender)
        {
            Random rand = new Random();
            float critRoll = rand.Next(100);

            if (critRoll > CritP)
            {
                _dmg = AP / _defender.DP * 2;
                _defender.TakeDamage(_dmg);
            }
            else if (critRoll <= CritP)
            {
                _dmg = AP / _defender.DP * 5;
                _defender.TakeDamage(_dmg);
            }
        }
    }
}
