namespace MonsterKampfSimulator.Monster
{
    public class Ork : Monster
    {
        public float DumbnessP;

        public Ork(string _name, float _currentHP, float _AP, float _DP, float _SP, float _DumbnessP = 10) : base(_name, _currentHP, _AP, _DP, _SP)
        {
            DumbnessP = _DumbnessP;
            IsOrk = true;
        }

        public override void Attack(float _dmg, Monster _defender)
        {
            Random rand = new Random();
            float dumbnessRoll = rand.Next(100);

            if (dumbnessRoll > DumbnessP)
            {
                _dmg = AP / _defender.DP * 2;
                _defender.TakeDamage(_dmg);
            }
            else if (dumbnessRoll <= DumbnessP)
            {
                _dmg = CurrentHP - AP;
                TakeDamage(_dmg);
            }

        }
    }
}
