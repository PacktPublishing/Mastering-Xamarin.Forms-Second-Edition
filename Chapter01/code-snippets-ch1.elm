-- the starting example 

import Html exposing (text)

multiplyNumber x y = 
  x * y

main =
  text ( toString ( multiplyNumber 8 10 ) )


  
-- another way to write the above 

  text ( toString ( multiplyNumber 2 ( multiplyNumber 2 ( multiplyNumber 2 10 ) ) ) )


  
-- piped syntax

import Html exposing (text)

multiplyNumber x y = 
  x * y

main =
  multiplyNumber 2 10
    |> multiplyNumber 2
    |> multiplyNumber 2
    |> toString
    |> text

	

-- the starting example, re-written

import Html exposing (text)

multiplyNumber x y = 
  x * y

main =
  multiplyNumber 8 10
    |> toString
    |> text



-- helpful type system

import Html exposing (text)

multiplyNumber: Int -> Int -> Int
multiplyNumber x y = 
  x * y

main =
  multiplyNumber 8 10
    |> toString
    |> text



-- Get started writing Elm code

import Html exposing (text)

main =
 text "Hello, World!"



-- With h1 function

import Html exposing (..)
 main =
 h1 [] [ text "Hello, Elm!" ]
 


-- With h2 function
h2 [] [ text "Hello, Elm!" ]


-- Making a link
main =
 a [] [ text "Hello, Elm!" ]


-- Making an li
main =
 li [] [ text "Hello, Elm!" ]


-- Making a paragraph
main =
 p [] [ text "Hello, Elm!" ]


-- Making a paragraph
main =
 p [] [ text "Hello, Elm!" ]


-- Nesting Html functions
import Html exposing (..)

main =
 div []
 [ p [] [text "1st paragraph" ]
 , p [] [text "2nd paragraph" ]
 ]


-- Adding attributes
import Html exposing (..)
import Html.Attributes exposing (class)

main =
 div [ class "danger" ]
 [ p [] [text "1st paragraph" ]
 , p [] [text "2nd paragraph" ]
 ]


-- Making a paragraph
main =
 p [] [ text "Hello, Elm!" ]

 
-- Updating the style HTML tag in Ellie app
.danger {
  background: red;
}


-- Adding type annotations
import Html exposing (..)
import Html.Attributes exposing (class)

main : Html msg
main =
  div [ class "danger" ]
  [ p [] [text "1st paragraph" ]
  , p [] [text "2nd paragraph" ]
  ]


--  Get started fast with create-elm-app
npm install create-elm-app -g

create-elm-app elm-fun

elm-app start


-- Main.elm

import Html exposing (..)
import Html.Attributes exposing (class)

import Html exposing (..)

main : Html msg
main =
  div [ ]
  [ h1 [] [text "Elm is fun!" ]
  , p [] [text "Let's learn some more!" ]
  ]


-- Get started with Elm on Windows 10
npm install -g elm

npm install -g elm-oracle

where.exe elm-oracle

C:\User\PC\AppData\Local\atom\app-1.19.7
C:\User\PC\AppData\Local\atom\app-1.19.7\resources\app\apm\bin

apm install atom-beautify
apm install elm-format

C:\Program Files (x86)\Elm Platform\0.18\bin

where.exe elm

C:\Program Files (x86)\Elm Platform\0.18\bin\elm-format.exe

-- testing elm-format with a poorly formatted elm file
-- command to run:
-- elm-format .\poorly-formatted-file.elm
module Main exposing (..)
import Html exposing (Html, text)
main =
text "Hello, Elm!"

apm install linter
C:\Users\PC\.atom\packages

elm-package install -y

-- Add some code to Main.elm to make sure it works:
module Main exposing (..)
import Html exposing (Html, text)

main =
    text "Hello, Elm!"