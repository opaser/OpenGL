cmake_minimum_required(VERSION 3.0)
project(client)

include_directories(${CMAKE_CURRENT_SOURCE_DIR})

aux_source_directory(${CMAKE_CURRENT_SOURCE_DIR} LIB_SRCS)

SET(EXECUTABLE_OUTPUT_PATH ${CMAKE_CURRENT_SOURCE_DIR}/makefile/)
add_executable(cx_opengl ${LIB_SRCS})
target_link_libraries(cx_opengl GL)
target_link_libraries(cx_opengl GLU)
target_link_libraries(cx_opengl glut)
