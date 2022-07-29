# Homework 2

This program is designed to conduct test fights between two or more players in any game. It allows you to track changes in the characteristics of players with existing characteristics. This program uses a class hierarchy, a delegate, an event, and its own collection.

The program consists of the following components:

- Each player has their own **inventory** with slots for **clothes** and **weapons**.

- Weapon slots are a **custom collection** of four slots (maybe more). These cells are navigated using **enumeration**.

- Clothes slots are slots for **helmet**, **body** clothes, **boots** and **gloves**.

- Items:
    - Base items are classes of armor, weapons and item class:
        - Each **item** has its own *name* and *weight*.
        - Each **armor** has a *protection* value that absorbs some damage.
        - Each weapon has its own *speed* and *damage*, as well as a *damage method*.
    - Quivers:
        - **Arrow Quiver** designed to store arrows for **bow**, each quiver has *damage* for one arrow and *amount* of remaining arrows.
        - **Quiver of bolts** designed for **crossbow**.
    - Weapons and Armor:
        - Armor on the body.
        - Boots.
        - The bow has a quiver for arrows, if there are no arrows in the quiver, then the bow does not shoot and a corresponding message is displayed.
        - The crossbow is similar to the bow.
        - Gloves.
        - Helmet.
        - **One-Handed Weapon**.
        - **Two-handed weapon**.
        - **Thrown weapons** have quantity property.
        - **Shield** has an additional *size* property.

- **Player** has a *name*, a property to determine if *he is alive*, an inventory, a property to determine *if there is a shield*, *health*, *load*, which affects *strength* and *speed* of hitting , also has *intelligence* and the amount of armor on it. There is an **event** to carry out an attack.
  When carrying out an attack, it is checked whether both players are alive. Next, the damage dealt is formed (if the player attacks without a weapon, this is also taken into account). If the player has a shield, then he has a chance to repel an attack. Next, a message about the attack is displayed.

Two players are created in the program, *regeneration* is added to the second player with each attack. Next, both players equip and attack each other in turn with random weapons from their inventory until one of them runs out of lives.
