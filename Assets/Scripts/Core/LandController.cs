using UnityEngine;

public class LandController : PlaceableObject
{
    [Header("Sprite")]
    [SerializeField] private Sprite landSprite;
    [SerializeField] private Sprite tomatoSprite;
    [SerializeField] private Sprite blueberrySprite;
    [SerializeField] private Sprite strawberrySprite;
    [SerializeField] private Sprite cowSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Place()
    {
        base.Place();

        if (landSprite != null)
        {
            spriteRenderer.sprite = landSprite;
        }
    }
}
