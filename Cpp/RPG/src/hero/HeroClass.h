#include <iostream>
#include <string>
#include <utility>
#include <list>
#include "src/skills/SkillClass.h"
#include "src/artifacts/ArtifactClass.h"

#ifndef RPG_HERO_H
#define RPG_HERO_H


class HeroClass {
public:
    std::string getHeroName() const{return this->HeroName;}
    std::string getGradeName() const{return this->GradeName;}
    std::list <SkillClass> getSkills() const{return this->skills;}
    int getHP() {return this->HP;}
    int getLevel() {return this->level;}
    int getExperience() {return this->experience;}
    int getDamage() {return this->damage;}
    int getDefense() {return this->defense;}
    int getKnowledge() {return this->knowledge;}
    int getMagic_power() {return this->magic_power;}
    int getMana() {return this->mana;}
    int getGold() {return this->gold;}
    std::list<ArtifactClass> getInventory() {return this->inventory;}
    int getHPAll() {
        int finalHP = this->maxHP;
        finalHP+=ArtifactHelmet.getHP();
        finalHP+=ArtifactArmor.getHP();
        finalHP+=ArtifactHands.getHP();
        finalHP+=ArtifactLegs.getHP();
        return finalHP;}
    int getDamageAll() {
        int finalDamage = this->damage;
        finalDamage+=ArtifactHelmet.getDamage();
        finalDamage+=ArtifactArmor.getDamage();
        finalDamage+=ArtifactHands.getDamage();
        finalDamage+=ArtifactLegs.getDamage();
        return finalDamage;}
    int getDefenseAll() {int finalDefense = this->defense;
        finalDefense+=ArtifactHelmet.getDefense();
        finalDefense+=ArtifactArmor.getDefense();
        finalDefense+=ArtifactHands.getDefense();
        finalDefense+=ArtifactLegs.getDefense();
        return finalDefense;}
    int getKnowledgeAll() {int finalKnowledge = this->knowledge;
        finalKnowledge+=ArtifactHelmet.getKnowledge();
        finalKnowledge+=ArtifactArmor.getKnowledge();
        finalKnowledge+=ArtifactHands.getKnowledge();
        finalKnowledge+=ArtifactLegs.getKnowledge();
        return finalKnowledge;}
    int getMagicPowerAll() {int finalMagicPower = this->magic_power;
        finalMagicPower+=ArtifactHelmet.getMagicPower();
        finalMagicPower+=ArtifactArmor.getMagicPower();
        finalMagicPower+=ArtifactHands.getMagicPower();
        finalMagicPower+=ArtifactLegs.getMagicPower();
        return finalMagicPower;}
    int getManaAll() {int finalMana = this->mana;
        finalMana+=ArtifactHelmet.getMana();
        finalMana+=ArtifactArmor.getMana();
        finalMana+=ArtifactHands.getMana();
        finalMana+=ArtifactLegs.getMana();
        return finalMana;}


    void death(){
        std::cout << "Персонаж умер" << std::endl;
    }

    void dealt_damage(int damage)
    {
        this->HP-=(int)(damage*100 / (100 + (double)getDefenseAll()));
        this->check_death();
    }

    void heal(int heal_HP)
    {
        this->HP = heal_HP;
        if (this->HP > this->getHPAll()){
            this->HP = this->getHPAll();
        }
    }

    void setArtifactHelmet(const ArtifactClass& NewArtifactHelmet){
        if (NewArtifactHelmet.getType()==HELMET){
            this->inventory.push_back(this->ArtifactHelmet);
            this->ArtifactHelmet= NewArtifactHelmet;
        }
    }

    void setArtifactArmor(const ArtifactClass& NewArtifactArmor){
        if (NewArtifactArmor.getType()==ARMOR){
            this->inventory.push_back(this->ArtifactArmor);
            this->ArtifactArmor= NewArtifactArmor;
        }
    }

    void setArtifactHands(const ArtifactClass& NewArtifactHands){
        if (NewArtifactHands.getType()==HANDS){
            this->inventory.push_back(this->ArtifactHands);
            this->ArtifactHands= NewArtifactHands;
        }
    }

    void setArtifactLegs(const ArtifactClass& NewArtifactLegs){
        if (NewArtifactLegs.getType()==LEGS){
            this->inventory.push_back(this->ArtifactLegs);
            this->ArtifactLegs= NewArtifactLegs;
        }
    }

    void setSkill(const SkillClass& newSkill){
        if (newSkill.getLevel()<=this->getLevel()){
            this->skills.push_back(newSkill);
        }
    }

protected:
    explicit HeroClass(int HP=100,int maxHP=100, int level=1, int experience=0, int damage=0, int defense=0, int knowledge=0, int magic_power=0, int mana=0, int gold=100) :
            HP(HP), maxHP(maxHP), level(level),experience(experience),damage(damage),defense(defense),knowledge(knowledge),magic_power(magic_power),mana(mana),gold(gold){

    }
    std::string HeroName,
                GradeName;
    ArtifactClass ArtifactHelmet = ArtifactClass("Повязка", HELMET),
            ArtifactArmor = ArtifactClass("Лохмотья", ARMOR),
            ArtifactHands = ArtifactClass("Перчатки", HANDS),
            ArtifactLegs = ArtifactClass("Лапти", LEGS);
    std::list<ArtifactClass> inventory;
    int HP{},
        maxHP{},
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
            this->death();
        }
    }

    void check_level()
    {
        if (experience>=level*(100+(level*15))){
            experience-=level*(100+(level*15));
            this->up_level();
            this->check_level();
        }
    }

    virtual void up_level()
    {
        level+=1;
    }

};


#endif //RPG_HERO_H
