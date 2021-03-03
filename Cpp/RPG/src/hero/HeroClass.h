#include <iostream>
#include <string>
#include <utility>
#include <list>
#include "src/skills/SkillClass.h"

#ifndef RPG_HERO_H
#define RPG_HERO_H


class HeroClass {
public:
    std::string getHeroName() const{return HeroName;}
    std::string getGradeName() const{return GradeName;}
    std::list <SkillClass> getSkills() const{return skills;}
    int getHP() {return HP;}
    int getLevel() {return level;}
    int getExperience() {return experience;}
    int getDamage() {return damage;}
    int getDefense() {return defense;}
    int getKnowledge() {return knowledge;}
    int getMagic_power() {return magic_power;}
    int getMana() {return mana;}
    int getGold() {return gold;}

    void death(){
        std::cout << "Персонаж умер" << std::endl;
    }

    void dealt_damage(int damage)
    {
        HP-=damage;
        check_death();
    }

    void addExperience(int new_experience)
    {
        experience+=new_experience;
        check_level();
    }



protected:
    explicit HeroClass(int HP=100, int level=1, int experience=0, int damage=0, int defense=0, int knowledge=0, int magic_power=0, int mana=0, int gold=100) :
            HP(HP),level(level),experience(experience),damage(damage),defense(defense),knowledge(knowledge),magic_power(magic_power),mana(mana),gold(gold){

    }
    std::string HeroName,
                GradeName;
    int HP{},
        level{},
        experience{},
        damage{},
        defense{},
        knowledge{},
        magic_power{},
        mana{},
        gold{};
    std::list <SkillClass> skills{};

    void check_death(){
        if (HP<1){
            death();
        }
    }

    void check_level()
    {
        if (experience>=level*(100+(level*15))){
            experience-=level*(100+(level*15));
            std::cout << experience << std::endl;
            if (experience>0){
                level+=1;
                check_level();
            } else{
                level+=2;
            }

        }
    }

};


#endif //RPG_HERO_H
