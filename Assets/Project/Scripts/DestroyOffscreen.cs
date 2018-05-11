using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {
    public float Offset;    // a képernyő széle után mennyivel semmisüljön meg az objektum
    
    private Rigidbody2D _rigidbody2D;

    private bool _isOffScreen;
    private float _offScreenX;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        _offScreenX = 500 + Offset;    // ezt az X értéket elérve megsemmisíti magát az objektum
    }

    private void Update() {
        var positionX = transform.position.x;        // jelenlegi X pozíció
        var directionX = _rigidbody2D.velocity.x;    // jelenlegi X haladási irány

        // ha az X koordináta abszolút értéke nagyobb, mint a küszöbérték (kép széle + offset)
        if (Mathf.Abs(positionX) > _offScreenX) {
            if (directionX < 0 && positionX < -_offScreenX) {    // ha balra haladunk és balra mentünk ki a képből
                _isOffScreen = true;
            } else if (directionX > 0 && positionX > _offScreenX) {    // ha jobbra haladunk és jobbra mentünk ki a képből
                _isOffScreen = true;
            }
        } else {
            _isOffScreen = false;
        }
        
        // ha kimentünk a képből, megsemmisítjük az objektumot
        if (_isOffScreen) OnOutOfBounds();
    }

    private void OnOutOfBounds() {
        _isOffScreen = false;
        GameObjectUtil.Destroy(gameObject);
    }
}
