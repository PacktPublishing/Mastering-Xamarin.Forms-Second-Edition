-- Code snippets for chapter 2

-- Primitive types in Elm

'a'


'a' : Char


"a"


"a" : String


""" \
| This 
| is 
| a 
| multi-line
| string
| """
" \n This \n is \n a \n multi-line  \n string \n " : String


-- Data structures: lists, tuples, records, sets, arrays, and dictionaries

-- Lists

[ 1, 2, 3, 4 ]

[ 0.1, 0.2, 0.3, 0.4 ]

[ 'a', 'b', 'c' ]

[ 1, 2, 3, 'c' ]

[ "just", "a", "bunch", "of", "strings" ]


-- Tuples

( "abc", True )

[ ( 'a', 'b' ), ( 'c', 'd' ) ]

[ ( 'a', 'b' ), ( 'c' ) ]

('1','2','3','4','5','6','7','8','9','0')


-- Records

{ color="blue", quantity=17 }


-- Recalling beginnerProgram function
-- main : Html msg
main =
  beginnerProgram { model = 5, view = view, update = update }
  
-- REPL:
{ model = 5, view = view, update = update }

-- REPL:
view = "view info"

update = "update info"

{ model = 5, view = view, update = update }


-- Sets
module Main exposing (main)

import Html exposing (Html, text)
import Set

set = Set.fromList [1,1,1,2]

main : Html msg
main =
    text (toString set)


-- Arrays
module Main exposing (main)

import Html exposing (Html, text)
import Array

array = Array.fromList [1,1,1,2]
array2 = Array.get 0 array

main : Html msg
main =
    text ((toString array) ++ " " ++ (toString array2))


-- Dictionaries
module Main exposing (main)

import Html exposing (Html, text)
import Dict

dict = 
    Dict.fromList 
    [ ("keyOne", "valueOne")
    , ("keyTwo", "valueTwo") 
    ]

main : Html msg
main =
    text (toString dict)


-- Functions, if expressions, and types

multiplyBy5 num = 5 * num

appendSuffix n = n ++ "ing"

time = 24

if time < 12 then "morning" else "afternoon"


-- Revisiting Elm messages

import Html exposing (Html, button, div, text)
import Html.Events exposing (onClick)

main =
  Html.beginnerProgram { model = model, view = view, update = update }

-- MODEL
type alias Model = Int
model : Model
model =
  0

-- UPDATE
type Msg = Increment | Decrement
update : Msg -> Model -> Model
update msg model =
  case msg of
    Increment ->
      model + 1

    Decrement ->
      model - 1

-- VIEW
view : Model -> Html Msg
view model =
  div []
    [ button [ onClick Decrement ] [ text "-" ]
    , div [] [ text (toString model) ]
    , button [ onClick Increment ] [ text "+" ]
    ]




-- -----------------------------------------

-- -----------------------------------------

-- Union types
type Vehicle = Car | Bike | Boat | Helicopter

friendsRide = Helicopter

type Msg = Increment | Decrement




-- Functions, pattern matching, and case expressions
--
update msg model =
  case msg of
    Increment ->
      model + 1

    Decrement ->
      model - 1

-- 
update whatever model =
  case whatever of
    Increment ->
      model + 1

    Decrement ->
      model - 1


--
Increment ->
      model + 1


-- Improving Fruit Counter app (full code)
module Main exposing (..)

import Html exposing (..)
import Html.Events exposing (onClick)

-- main : Html msg
main =
    Html.beginnerProgram
        { model = 5
        , update = update
        , view = view
        }
  
-- MODEL
type alias Model = 
    Int

-- VIEW
view model =
    div [] 
        [ h1 [] [ text ("Fruit to eat: " ++ (toString model)) ] 
        , button [ onClick Decrement ] [ text "Eat fruit" ]
        , button [ onClick Reset ] [ text "Reset counter" ]
        ]   

-- MESSAGE
type Msg = Decrement | Reset
     
-- UPDATE
update msg model =
    case msg of
        Decrement -> 
            if model >= 1 then 
                model - 1
            else
                5
        Reset -> 
            5

-- -----------------------------------------
-- -----------------------------------------
-- Building a simple fizz-buzz app in Elm

{-
12 % 10

10 % 9

19 % 9

3 % 3

5 % 5

15 % 15
-}

module Main exposing (main)

import Html exposing (text)

fizzBuzz = "Fizz Buzz"
fizz = "Fizz"
buzz = "Buzz"

fizzBuzzInput value = 
    if value % 15 == 0 then
        fizzBuzz
    else if value % 3 == 0 then
        fizz
    else if value % 5 == 0 then
        buzz
    else (toString value)

main =
    text (fizzBuzzInput 34567)

{-
main =
    fizzBuzzInput 34567
    |> text 
-}




	