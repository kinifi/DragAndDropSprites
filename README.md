# DragAndDropSprites
drag and drop sprite framework for Unity in 2D using Sprites


### DragAndDropManager

Controls what objects can be dropped on. This will always have a single instance and will destroy other instances if they exist. 

Properties Include: 

- GameObject[] m_PlacedObjects - An array of GameObjects we can drop onto. 
- bool isDragging - Are we currently dragging and object?
- bool enableSnapping - Snap Objects when dropped to the middle
- Transform m_PreviousPosition - The Position we started dragging the Object

Methods: 

- Init() - Called when the instance has been created
- public bool isPlaced(GameObject setDownGameObject) - Used for objects that can be dragged to check if they can be dropped
  - Controls callbacks

Callbacks (Not Required):
- OnPlaced(GameObject theObjectBeingPlacedOn) - called on the object that is being dragged after its been dropped
- OnPlaced(GameObject theObjectThatIsDroppingOnSelf) - called when the object has something dropped on it
