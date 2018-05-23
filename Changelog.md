# Changelog

## [InDev] Last Update - 2018/05/23
### Added
#### Prestige System
* Players can now gain prestige levels (PL)
* Prestige levels allow the player to exceed the base skill cap and gain other bonuses
* Each level a player takes will permanently increase the skill gain difficulty for that player
* This is not reversible
* Four levels
    * Level 0 - Base (770) skill cap, no bonus, OSI difficulty
    * Level 1 - 1440 skill cap, + 2x OSI difficulty
    * Level 2 - 2100 skill cap, +150 luck, + 4x OSI difficulty
    * Level 3 - unlimited (70000) skill cap, + 150 luck, 10% bonus to base Hits/Mana/Stam, varaible difficulty
        * If a skill is 60.0 or below difficuly is 4x OSI
        * If a skill is 80.0 or below difficuly is 6x OSI
        * If a skill is 100.0 of below difficuly is 8x OSI
        * If a skill is above 100.0 difficulty is 10x OSI
* In addition to bonuses in-game name color changes based on level
    * Level 1 - Bronze
    * Level 2 - ???
    * Level 3 - ???
* Power Scrolls are limited based on prestige level
    * Level 0 can consume scrolls up to 105
    * Level 1 can consume scrolls up to 110
    * Level 2 can consume scrolls up to 115
    * Level 3 can consume any scroll
* Any player who is PL 1 or greater no longer get Guaranteed Gain System (GGS)
* Various configuration bits to control PL system (see: PrestigeLevel.cfg in /Config)
* PL command - Will let players know what PL they are at
### Removed
### Changed
* PL characters will not receive GGS if PL > 1
* Difficulty will scale based on PL (see: Prestige System)
* Character name colors will be based on PL
### Fixed
### Security
