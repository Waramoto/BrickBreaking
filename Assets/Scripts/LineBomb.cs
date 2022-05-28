using System.Linq;

public class LineBomb : Bomb
{
    public override void Disappear()
    {
        var blocks = FindObjectsOfType<Block>().ToList();
        var bombs = FindObjectsOfType<Bomb>().ToList();
        
        for (var i = blocks.Count - 1; i >= 0; i--)
        {
            var goPos = gameObject.transform.position;
            var blockPos = blocks[i].gameObject.transform.position;

            if (goPos.y != blockPos.y)
            {
                blocks.RemoveAt(i);
            }
        }

        for (var i = bombs.Count - 1; i >= 0; i--)
        {
            var goPos = gameObject.transform.position;
            var bombPos = bombs[i].gameObject.transform.position;
            
            if (goPos.y != bombPos.y || goPos == bombPos)
            {
                bombs.RemoveAt(i);
            }
        }
        
        foreach (var b in blocks)
        {
            b.Disappear();
        }

        foreach (var b in bombs)
        {
            b.IsDestroyed = true;
            Destroy(b.gameObject);
        }
        
        base.Disappear();
    }
}