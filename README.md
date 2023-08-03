# Unity Notes
Always check [the docs](https://docs.unity3d.com/)

## Codes

public attributes starts with a capitalized carater, private don't 

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

#### Rigidbody2D
The Rigidbody2D component in Unity is used to apply physics-based movement and interactions to 2D GameObjects. It enables objects to be affected by forces like gravity, collisions, and impulses, allowing for realistic and dynamic movement and interaction in a 2D environment.
It has two different collision mode option, **discrete** collision detection checks for collisions at fixed intervals, such as every frame or every update cycle, **continuous** collision detection checks for collisions along the entire trajectory of an object, such as a bullet or a fast-moving character.
Use continuous collision detection for fast moving object, like an arrow for example.

#### Polygon Collider 2D
define collision shapes for 2D game objects. It allows you to create a polygonal shape that accurately matches the outline of your game object, which can be used for collision detection with other game objects in the scene.
Use it when you need a precise collision shape.

The "Is Trigger" option can be useful in situations where you want to detect when two objects have collided, but you don't necessarily want them to interact physically, such as detecting when a player has walked into a certain area or when a bullet has hit a target.

#### Sorting Group
This component allows you to control the rendering order of objects in a scene. When multiple objects are rendered on the screen, their order can affect how they are displayed, with objects that are closer to the camera appearing in front of objects that are farther away. The Sorting Group component allows you to specify a custom sorting order for a group of objects, which can be useful for creating complex 2D or 3D scenes.

#### Trail Renderer
The Trail Renderer is used to create dynamic trails behind moving objects, such as particle effects, projectile paths, or character movements, by rendering a series of fading segments based on the object's motion.

#### Tilemap
The Tilemap component in Unity is used to create and manage 2D tile-based environments. It provides a grid-based system where you can paint tiles onto the grid to define the visual layout and collision properties of your level.

#### Tilemap Renderer
The Tilemap Renderer component in Unity is responsible for rendering the visual representation of a Tilemap. It works in conjunction with the Tilemap component to display the painted tiles on the screen, applying any associated materials and textures to create the final visual output of the tile-based environmen

#### Tilemap Collider 2D 
The Tilemap Collider 2D component in Unity is used to define collision boundaries for a Tilemap. It allows game objects to interact with the tiles by detecting collisions and triggers. This component works hand-in-hand with the Tilemap component to provide accurate and efficient collision detection in a tile-based environment.

#### Composite Collider 2D
The Composite Collider 2D component in Unity is used to create a composite shape for collision detection in 2D physics simulations. It combines multiple colliders attached to a game object into a single collider, optimizing collision detection performance. This component is particularly useful for complex or irregularly shaped objects that require precise and efficient collision handling.

#### Grid Layout Group
Useful for placing objects in a same way together, for example when placing boxes of an inventory in a x+y place

## Tilemap Sprite Atlas
When working with Tilemaps to create the maps element, sometimes the elements doesn't fit correctly together and it's making weird missing pixel lines, using the Tilemap Sprite Atlas object and putting the Tilemap image file that is concerned by dropping it in "Objects for packing" can resolve the issue (set the compression to *none*)

## Animations
When the object that is animated is not moving or in a none state, we call this an Idle animation.

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

## Unity custom types

## Animation Curve
Creates an animation curve from an arbitrary number of keyframes  
It can be useful when creating a ballistic moving element directly as a [SerializeField]  
Unity doc reference: [Animation Curve](https://docs.unity3d.com/ScriptReference/AnimationCurve.html)

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

### OnValidate
It's useful to work with this one with "[SerializeField]" especially when you're working with multiple people, 
it allows you to put default value or check on the SerializeFields for example.  

## Scenes
When working with scene, make sure to add the needed one on the build  
File -> Build settings, there drag and drop scenes in "Scenes in build"

### Prefab
Option Prefab -> Unpacking completely:   
Unpacking a prefab can be useful when you want to modify the individual elements of a prefab or customize them further. After unpacking, you have full control over each component, allowing you to make changes without affecting other instances of the prefab. It also allows you to access and modify the properties and settings of each component directly.

# Game Assets
## Free
https://anokolisa.itch.io/dungeon-crawler-pixel-art-asset-pack
https://game-endeavor.itch.io/mystic-woods
https://arks.itch.io/dino-characters
https://clembod.itch.io/warrior-free-animation-set
https://penzilla.itch.io/hooded-protagonist
https://elthen.itch.io/2d-pixel-art-gladiator-sprites
https://deepdivegamestudio.itch.io/dragon-asset-pack

Minifantasy free assets  
https://krishna-palacio.itch.io/minifantasy-forgotten-plains
https://krishna-palacio.itch.io/minifantasy-dungeon

Sprites generator  
https://sanderfrenken.github.io/Universal-LPC-Spritesheet-Character-Generator/#?body=Body_color_light&head=Human_male_light

## Not free
7.50$ (the Twisted one for invisible character)
https://clembod.itch.io/cultist-enemy-pack   

What about the traps, could be a good idea to implement, like trap events 
https://rafaelmatos.itch.io/epic-rpg-world-pack-old-prison-asset-tileset 

Where there is this super beautiful Dragon
https://electriclemon.itch.io/ 

Pixel effects
https://nyknck.itch.io/ 

Literally the best complete one  
https://itch.io/s/45421/minifantasy-complete-bundle 

Only creatures & effects from minifantasy  
https://itch.io/s/94077/minifantasy-creatures-bundle