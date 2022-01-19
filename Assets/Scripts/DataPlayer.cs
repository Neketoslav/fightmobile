using System.Collections.Generic;

public class DataPlayer
{
    private List<IEnemy> enemies = new List<IEnemy>();

    public void Attach(IEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void Detach(IEnemy enemy)
    {
        enemies.Remove(enemy);
    }

    protected void Notifier(DataType dataType)
    {
        foreach(var enemy in enemies)
        {
            enemy.Update(this, dataType);
        }
    }
}
