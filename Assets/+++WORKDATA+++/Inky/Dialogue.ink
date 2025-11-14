-> start
=== start ===
2 Unknown Guys look at you and Say "We are The Twins Alfred and Alfredo. Who are You"
-> main_talk

=== main_talk ===
Fred (You): Hmm…

* "Im Fred, nice to meet You guys."
    -> Welcome_Disscussion

* "Why Should I care?"
    -> rude_discussion

=== Welcome_Disscussion ===
Alfred: "Welcome to this World."
Alfredo: "We Love it here, but we dont know why."

* "Did You guys find A way out?"
    -> escape_discussion

* "It is kinda nice here!"
    -> Home_discussion

=== rude_discussion ===
Alfred and Alfredo:" Dude that is not cool, we are just Chillin here!!!"

* "I Just wanna Leave!"
    Alfred: "Okay, but there is no reason to be rude."
    Alfredo: " Yeah thats right."
    Fred (You): "Did you guys find a way out?" 
    -> escape_discussion

* "I am sorry, I really need to calm down. Please let me introduce myself again"
    -> main_talk

=== Home_discussion ===
Alfredo: "Yeah we think the Same Way, right Alfred?"
Alfred: "Yeah, It is so Mysterious Here."

* "Mysterious? I LOVE THAT!"
    Fred: "Mysterious? I LOVE THAT! I will stay here with you"
    -> END

* "We Can Explore this world together."
    Alfred and Alfredo:" Thats Dope Bro, lets do that."
    -> END

=== escape_discussion ===
Alfred: " Yeah bro, we saw the Exit just over there. It is not Far from here.

* "Thank you, I will leave this Shitty World!"
    Alfred: "Okay Dude, See you Around"
    Alfredo: "Be careful there might be Monster luring around
    Fred (You): "Thank you I will. bye."
    -> END

* "I Think I might Stay for a while if thats OK?"
    -> Home_discussion