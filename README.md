Hero vs Monster - Turn-Based Battle Game (Unity)

This project is a simple turn-based combat game implemented in Unity. It demonstrates core Object-Oriented Programming (OOP) principles such as inheritance, polymorphism, encapsulation, and abstraction, along with the use of design patterns like Strategy, Composite, and State.

##  Features

- Hero and Monster take turns attacking each other
- Visual attack motion and animations (Attack, Hit, Die)
- Health UI updates dynamically
- Uses clean, modular OOP architecture
- Implemented design patterns:
  - Strategy (Character States)
  - Composite (ComboAttack)
  - State (Character state transitions)


##  Getting Started

###  Requirements

- Unity 2021.3 or newer
- TextMeshPro (comes with Unity)
- Animator Controller (for Hero and Monster)
- Unity UI Toolkit or Canvas UI system

---

## Setup Instructions

1. **Clone or Download the Project**

   ```bash
   git clone https://github.com/your-username/hero-vs-monster.git
Open in Unity

Launch Unity Hub

Click "Add" and select the project folder

Open the project

Scene Setup

Create an empty GameObject called BattleManager

Attach the BattleManager.cs script

Drag your Hero and Monster GameObjects into the BattleManager inspector fields

Character Prefabs

Add Hero and Monster prefabs to the scene

Attach:

Hero.cs or Monster.cs (inherits Character)

Animator component (with Attack, Hit, Die triggers)

CharacterUI.cs script

Set characterName in the inspector

Assign UI reference (e.g., name text and health bar)

Animator Setup (Optional but Recommended)

Create Animator Controller

Add triggers: Attack, Hit, Die

Assign animations and transition between states

 How to Play
The game starts automatically.

Hero and Monster take turns attacking each other.

Damage is logged in the console.

Health is reduced and updated in the UI.

When a character’s health reaches zero:

"Die" animation is triggered

GameObject is destroyed

Combat loop ends

 Learning Goals
This project demonstrates:

OOP in Unity (Classes, Abstraction, Interfaces)

Design pattern implementations

Unity Coroutines for visual motion

Separation of logic (UI, Animation, State)

Basic turn-based game architecture

 Folder Structure 
markdown
Copy
Edit
/Assets
  /Scripts
    Character.cs
    Hero.cs
    Monster.cs
    AttackComponent.cs
    ComboAttack.cs
    ICharacterState.cs
    IdleState.cs
    AttackState.cs
    DeadState.cs
    BattleManager.cs
    CharacterUI.cs
  /Prefabs
    Hero.prefab
    Monster.prefab
  /Animations
    HeroAnimator.controller
    MonsterAnimator.controller
  /UI
    HealthBar.prefab
    PlayerText
    
 License
MIT License — free to use, modify, and share.

 Credits
Developed by Taiwo Adegboyega

Built with Unity Engine
