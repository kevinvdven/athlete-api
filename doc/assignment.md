# Assignment
You have been tasked with designing data storage for information about young athletes, and
providing search functionality for it. The data contains: name, birthdate, skills, and
championships in which the athlete has participated. For instance:
```
-----
Name: Anna Gasser
Birthdate: August 16, 1991
Skills: Winter sports, snowboarding, gymnastics
Championships: World Snowboard Tour 2010, World Snowboard Tour 2011, FIS Snowboarding
World Championship 2013, Winter Olympics 2014, FIS Snowboarding World Championship
2015, FIS Snowboarding World Championship 2016, FIS Snowboarding World Championship
2017
-----
Name: Tess Ledeux
Birthdate: November 23, 2001
Skills: Skiing
Championships: FIS race 2016, FIS Freestyle World Championship 2017
-----
Name: Nairo Quintana
Birthdate: February 4, 1990
Skills: Cycling
Championships: Route du Sud 2012, Tour of the Basque Country 2013, Tour de France 2014,
Tour de France 2015, Tour de France 2016
-----
```

Note that some skills may be supersets of others. For example, "winter sports" is a superset of
"snowboarding" and "skiing". So, if you search for "winter sports" on the dataset above, it should
match "Anna Gasser" and "Tess Ledeux" (even though Tess's entry doesn't list it explicitly), but
if you search for "snowboarding", it should only match "Anna Gasser".

You should allow searching by:
- Name
- Age range: <18, 18-21, 22-25, 26-30, >30)
- Skill(s)
- Professional experience (in years)

What we expect from you:
- A description of the data store (such as a schema, or diagram), with examples if
necessary;
- Code for the search that satisfies the criteria above. Please note:
    - The code should be correct and expected to work if we reproduce your designed
data storage solution (bonus points if you produce a "dump" of sample data in a
way that we can easily load and test).
    - We should be able to invoke the search with different parameters, by some
reasonable means - a command-line interface, a library, or even just a function.
You are not expected to provide a graphical user interface though you can :)
- Explanation of design decisions and trade-offs you've made.

You may use the programming language and any frameworks and libraries of your preference,
but please be explicit about the tools you used, so we can reproduce your setup. If you intend to
use something "esoteric", please ask us first - the point of this exercise is for us to assess your
coding skills and perform an informed code review, and it loses its meaning if we can't
understand it.

You can send us a link to a repository or a zipfile with your solution.

Have fun!
