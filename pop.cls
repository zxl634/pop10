%% Class file to documents for the course POP
\NeedsTeXFormat{LaTeX2e}[1995/12/01]
\ProvidesClass{pop}[2017/12/10 LaTeX document class for POP]

%% Based on the article class
\LoadClass[11pt,a4paper]{article}

%% Used packages
\usepackage[utf8]{inputenc}
\usepackage[T1]{fontenc}
%\usepackage{listings}
\usepackage{listingsutf8}
\usepackage{color}
\usepackage{graphicx}
\usepackage{lmodern}
\usepackage[danish]{babel}
\usepackage[colorlinks=true, linkcolor=red, urlcolor=blue, filecolor=cyan,%
citecolor=green, anchorcolor=magenta]{hyperref}          %% hyperlinks from TOC/ref/url to whatever
\usepackage[all]{hypcap}
\usepackage{geometry} 
\usepackage[danish]{datetime2}
\usepackage{amsmath, amsfonts, amssymb}
\definecolor{bluekeywords}{rgb}{0.13,0.13,1}
\definecolor{greencomments}{rgb}{0,0.5,0}
\definecolor{turqusnumbers}{rgb}{0.17,0.57,0.69}
\definecolor{redstrings}{rgb}{0.5,0,0}
\definecolor{lightgray}{gray}{0.97}

\lstdefinelanguage{FSharp}
   {morekeywords={let, new, match, with, rec, open, module, namespace, type, of, member, and, for, in, do, begin, end, fun, function, try, mutable, if, then, else},
    keywordstyle=\color{bluekeywords},
    sensitive=false,
    morecomment=[l][\color{greencomments}]{///},
    morecomment=[l][\color{greencomments}]{//},
    morecomment=[s][\color{greencomments}]{{(*}{*)}},
    morestring=[b]",
    stringstyle=\color{redstrings}
  }

\lstset{language=FSharp,
    basicstyle=\footnotesize\ttfamily, 
    linewidth=\linewidth,
    backgroundcolor=\color{lightgray},
    numbers=left,
    frame=single,
    breaklines=true,
    breakatwhitespace=true,
    showstringspaces=false,
    captionpos=tb,  %% filnavn i top OG bund
    keepspaces=true,
    title=\lstname,
    inputencoding=utf8/latin1  %% nødvendig for UTF8
  }

\lstdefinestyle{snippet} {
    title= (\lstname), captionpos=b,
  }

  % For at kunne printe med VerbatimInput
\usepackage{fancyvrb}

% Bruger-definerede kommandoer
\newcommand{\ty}[1]{\texttt{#1}}
