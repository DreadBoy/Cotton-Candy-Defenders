#How to export and use models

When exporting models from SketchUp, make sure that centre of bottom tower face is at the same spot as world origin. That is to make programmer's life simpler since he only need to Instantiate a prefab at y=0. 

When are you making prefab from models, make sure you also include script called TowerStats where you define a shot position. Shot position determines where projectiles should originate from.