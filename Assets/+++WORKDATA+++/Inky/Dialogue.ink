-> start
=== start ===
Alfred: We are the twins, Alfred and Alfredo.
Alfredo: Yeah! So… who are you?

-> main_talk


=== main_talk ===
Fred: Hmm…

* "I'm Fred. Nice to meet you guys."
    -> welcome_discussion

* "Why should I care?"
    -> rude_discussion
    
* Player: "Piss off, idiots!"
    -> die_discussion



=== welcome_discussion ===
Alfred: Welcome to this world.
Alfredo: We love it here… though we don’t really know why.

Fred:

* "Have you guys found a way out?"
    -> escape_discussion

* "Honestly, it's kinda nice here."
    -> home_discussion



=== rude_discussion ===
Alfred: Dude, that's not cool.
Alfredo: Yeah bro, we’re just chilling here!

* "I just want to leave!"
        Alfred: Okay… but you don’t have to be rude.
        Alfredo: Yeah, seriously dude.
        Fred: Have you at least found a way out?
        -> escape_discussion

* "Sorry. I need to calm down. Let me introduce myself again."
        -> main_talk



=== home_discussion ===
Alfredo: We feel the same way! Right, Alfred?
Alfred: Yeah, it's mysterious here.

* "Mysterious? I LOVE THAT!"
        Fred: Mysterious? I LOVE THAT! I'll stay here with you guys.
        -> END

* "We can explore this world together."
        Alfred: That’s dope, bro!
        Alfredo: Let’s do it!
        -> END



=== die_discussion ===
Alfred: That's it! You're dead! No one insults my brother!

The twins eat you whole.
-> END



=== escape_discussion ===
Alfred: Yeah bro, we saw the exit just over there. It isn't far.

* "Thanks! I'm getting out of this weird world!"
        Alfred: Alright dude, see you around.
        Alfredo: Be careful… there might be monsters lurking out there.
        Fred: Thanks. Bye.
        -> END

* "Actually… I think I might stay for a while, if that’s okay?"
        -> home_discussion