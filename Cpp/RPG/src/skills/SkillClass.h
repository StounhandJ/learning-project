#include <iostream>
#include <string>
#include <utility>
#ifndef RPG_SKILLCLASS_H
#define RPG_SKILLCLASS_H

int const NON_ELEMENT = 0;

class SkillClass {
public:
    int getLevel() const{return level;}
    int getPower() const{return power;}
    int getCost() const{return cost;}
    int getElement() const{return element;}

    explicit SkillClass(std::string name, int level, int power, int cost, int element):
        name(std::move(name)), level(level), power(power), cost(cost), element(element)
    {

    }

private:
    int level,
        power,
        cost,
        element;
    std::string name;
};
#endif //RPG_SKILLCLASS_H
