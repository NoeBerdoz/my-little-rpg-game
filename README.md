# Unity Notes
Always check [the docs](https://docs.unity3d.com/)

## Codes

```C#
    [SerializeField] private int myValue = 10;
```
The [SerializeField] attribute in C# is used in Unity to indicate that a field should be serialized by the Unity editor.

In Unity, serialization is the process of converting the state of an object into a format that can be stored, transmitted, or saved in the Unity editor. 
This allows you to set the value of the field through the Unity editor interface.

## Player Controllers
The player controllers is as a Player Controls type file
There from the editor you set the keys and their calls, and you can call them in your scripts


## Editor

When selecting an object that is a Prefab, if you modify it it will modify every inheritance, 
You can duplicate it to make another Prefab with the option, _right click -> Prefabs -> "Unpack completely"_ 
This option is useful when you want to make unique modifications to a Prefab instance without affecting other instances.

## Sprites
When you edited a sprite, to make it as a template, put it in the Assets/Prefab folder, from the SampleScene list.

Sprite Mode selections in Unity:

**Single**: This mode is used for sprites that consist of a single image or texture. When this mode is selected, the sprite editor will display the image or texture as a single rectangle, which can be resized or repositioned as needed.

**Multiple**: This mode is used for sprites that consist of multiple images or textures, which are arranged in a grid or other pattern. When this mode is selected, the sprite editor will display a grid of rectangles, one for each sub-image, which can be individually resized or repositioned. This mode is commonly used for sprite sheets, which are collections of related sprites that can be animated or used in different contexts.

**Polygon**: This mode is used for sprites that have a non-rectangular shape, such as characters or objects with irregular outlines. When this mode is selected, the sprite editor will display the sprite as a polygon with multiple vertices, which can be added, deleted, or adjusted to match the sprite's shape. This mode is useful for creating precise collision shapes for 2D physics simulations.

Methods of collision detection: 

**Discrete** collision detection is the default method used by Unity. In this method, objects are checked for collisions at discrete points in time, usually once per frame. When two objects come close enough to each other, their colliders are tested for intersection. This approach is fast and efficient but can lead to missed collisions if objects are moving too fast or are too small. Discrete collision detection is often used for games that don't require high levels of physical accuracy or where performance is a concern.

**Continuous** collision detection, on the other hand, is a more accurate method of collision detection. In this method, objects are checked for collisions continuously between their current and next positions. This means that even fast-moving or small objects will be detected correctly, reducing the chance of missed collisions. However, continuous collision detection is more computationally expensive than discrete collision detection and can lead to a decrease in performance.

### Components

#### Capsule Colider 2D
type of collider in Unity that is used for 2D physics simulations. A Capsule Collider 2D is a 2D shape that is similar to a cylinder with rounded ends, and is often used to represent objects with a cylindrical or humanoid shape, such as characters or obstacles. When a Rigidbody2D component is attached to an object with a Capsule Collider 2D, it will be subject to physics simulations, such as gravity, collisions, and forces applied by other objects in the scene. The Capsule Collider 2D can be adjusted to fit the specific shape of the object it represents, allowing for precise collision detection and physics simulations.

#### Polygon Collider 2D
define collision shapes for 2D game objects. It allows you to create a polygonal shape that accurately matches the outline of your game object, which can be used for collision detection with other game objects in the scene.
Use it when you need a precise collision shape.

The "Is Trigger" option can be useful in situations where you want to detect when two objects have collided, but you don't necessarily want them to interact physically, such as detecting when a player has walked into a certain area or when a bullet has hit a target.

#### Sorting Group
This component allows you to control the rendering order of objects in a scene. When multiple objects are rendered on the screen, their order can affect how they are displayed, with objects that are closer to the camera appearing in front of objects that are farther away. The Sorting Group component allows you to specify a custom sorting order for a group of objects, which can be useful for creating complex 2D or 3D scenes.

#### Trail Renderer
The Trail Renderer is used to create dynamic trails behind moving objects, such as particle effects, projectile paths, or character movements, by rendering a series of fading segments based on the object's motion.

## Animations
In Assets/Animations create a **Animator Controller**

Add a Animator component to your Object, put the Controller on it, set the value for transitions and fixed duration to null.
In Animation, you can then click on the red record button, and then go to you Object and add the wanted key value by right clicking on it

Example of animation triggered on custom input key
```C#
public class Sword : MonoBehaviour
{

    private PlayerControls playerControls;
    private Animator myAnimator;

    private void Awake() {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    void Start()
    {
        // Call Attack function on control input Attack
        playerControls.Combat.Attack.started += _ => Attack(); // '_' synthax to not pass any parameters to the Attack ()
    }

    private void Attack() {
        myAnimator.SetTrigger("Attack");
    }

}
```

You can add Event on animations that will call a specific function on a setted time key


## Input Action Asset
This file type let's you set inputs Controllers, for example setting W for moving up, S for down, etc...
You add an action map, then set an action with a key binding.

## Useful Unity built-in functions

### Awake()
This function is called on an object when it is instantiated in the scene, before any Start() or Update() functions are called. The goal of the Awake() function is to initialize any data or components that the object needs in order to function properly, before any other scripts or functions start running.

### Start()
The goal of the Start() function is to initialize any data or components that require the object to be fully initialized before they can be set up, such as objects that depend on other objects or components.
The Start() function is typically used for tasks that need to be performed once at the beginning of an object's lifetime, such as setting up initial game state, initializing data structures, or performing other setup tasks that require the object to be fully initialized.

### Update()
The goal of the Update() function is to update the state of the object and perform any necessary computations or calculations for the current frame.
The Update() function is typically used for tasks that need to be performed every frame, such as updating the position or orientation of an object, checking for user input, or performing physics calculations. The Update() function is also commonly used for animations and other visual effects, as well as for managing game logic and state.

### ForceMode2D.Impulse
Leave feedback
Add an instant force impulse to the rigidbody2D, using its mass.
Apply the impulse force instantly. This mode depends on the mass of rigidbody so more force must be applied to move higher-mass objects the same amount as lower-mass objects.
This mode is useful for applying forces that happen instantly, such as forces from explosions or collisions.

### Coroutine
Anytime that you need something to work for only X amount of time, you need to set up a Coroutine
Coroutines are defined using the **IEnumerator** return type
Coroutine have to be called with *StartCoroutine()*
in Coroutines the *yield return* statement is a key feature in coroutines that allows for sequential execution, pausing, and nesting of coroutines.

# Game Assets
## Free
https://anokolisa.itch.io/dungeon-crawler-pixel-art-asset-pack
https://game-endeavor.itch.io/mystic-woods
https://arks.itch.io/dino-characters
https://clembod.itch.io/warrior-free-animation-set
https://penzilla.itch.io/hooded-protagonist
## Not free
https://clembod.itch.io/cultist-enemy-pack 7.50$ (the Twisted one for invisible character)
https://rafaelmatos.itch.io/epic-rpg-world-pack-old-prison-asset-tileset (What about the traps, could be a good idea to implement, like trap events)