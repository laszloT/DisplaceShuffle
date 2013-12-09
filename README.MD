This shuffle class takes in a generic list of unigue integers and shuffles them into a new list.


The NaturalShuffle Function returns a shuffled list where it is entirely possible for a value 
that occupies position N before the shuffle, to randomly shuffle to the same postiton N.    
The same would be true of all the other items in the list leaving an "even" distribution of items 
that did not move in the shuffle.  This is natural and fair, for example, when shuffling a deck of 
cards, it is entirely possible for the "Ace of Spades" to be in the fourth position in the
deck before the shuffle, and to just naturally end up in the fourth position afterward.
Perhaps all the other cards displaced, but the "Ace of Spades" did not on this occasion.  
This is allowable in a "Natural" shuffle.

The DisplaceShuffle guarantees that each item in the list will not land in the same position
it started from.  A common way of approaching this is to ask for a new position with a call to a 
pseudo-random number generator. Should the value of the current position be returned, ask for another.  
Repeat until a different value is returned.  This appraoch has the limitation of the impossibility to 
predict with complete accuracy how many times the random number generator will have to repeat before 
bringing back a different number, leaving the runtime of the algorithm questionable.  
The DisplaceShuffle function in this class does not have this weakness.  It makes as many calls
to Random() as there are elements in the list, and each is guaranteed to displace before the 
new List is returned.





 


