# Unity Notes

## Sprites
Sprite Mode selections in Unity:

**Single**: This mode is used for sprites that consist of a single image or texture. When this mode is selected, the sprite editor will display the image or texture as a single rectangle, which can be resized or repositioned as needed.

**Multiple**: This mode is used for sprites that consist of multiple images or textures, which are arranged in a grid or other pattern. When this mode is selected, the sprite editor will display a grid of rectangles, one for each sub-image, which can be individually resized or repositioned. This mode is commonly used for sprite sheets, which are collections of related sprites that can be animated or used in different contexts.

**Polygon**: This mode is used for sprites that have a non-rectangular shape, such as characters or objects with irregular outlines. When this mode is selected, the sprite editor will display the sprite as a polygon with multiple vertices, which can be added, deleted, or adjusted to match the sprite's shape. This mode is useful for creating precise collision shapes for 2D physics simulations.

Methods of collision detection: 

**Discrete** collision detection is the default method used by Unity. In this method, objects are checked for collisions at discrete points in time, usually once per frame. When two objects come close enough to each other, their colliders are tested for intersection. This approach is fast and efficient but can lead to missed collisions if objects are moving too fast or are too small. Discrete collision detection is often used for games that don't require high levels of physical accuracy or where performance is a concern.

**Continuous** collision detection, on the other hand, is a more accurate method of collision detection. In this method, objects are checked for collisions continuously between their current and next positions. This means that even fast-moving or small objects will be detected correctly, reducing the chance of missed collisions. However, continuous collision detection is more computationally expensive than discrete collision detection and can lead to a decrease in performance.