#Tower Defence game for Android in development

This is joint effort of two friends to make Android tower defence game, where you have to defend Cotton Candy against hordes of goblins, zombies, witches and whatnots. You are welcome to watch the repo and play dev builds as we develop it.


##Upgrade system
Each time you a complete level, you unlock a tower. Each tower you can upgrade by spending gold between each level and in main menu.


##Towers

* Basic tower (basic attacks, upgrade increases damage)
* Slowing tower (slows units over time, upgrade increases duration)
* Stunning tower (stuns units over time, upgrade increases duration)
* Piercing tower (add bleeding damage over time, upgrade increases damage)
* Poisoned tower (add poison damage over time, upgrade increases damage)
* Fear tower (fears units - make them go back for a while, upgrade increases fear duration)
* Charm tower (charms units - make them attack other units, upgrade increases charm duration)

##Enemies
  This list is work in progress...
* goblins (low HP, fast moving, no resistance)
* ogres (high HP, slow moving, high damage resistance - armor)
* shamans (low HP, medium moving, high spell resistance - shield)


##New wave gameflow
As soon as you kill all enemies, small box pops up with "Good job" text and button to continue to next wave. It's probably good if there's displayed also the amount of gold you earned this wave and small tip "Don't forget to build new towers or upgrade existing". When you click a button, box should hide and big screen overlay should tell you which wave it is and how much is left until end. After few seconds (3?) it hides and you are allowed to build and upgrade towers. At top border of screen there's a button to start the wave.