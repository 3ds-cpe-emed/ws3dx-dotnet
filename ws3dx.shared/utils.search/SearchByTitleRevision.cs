// ------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2022 Dassault Systèmes - CPE EMED
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify,
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ------------------------------------------------------------------------------------------------------------------------------------

namespace ws3dx.utils.search
{
   public class SearchByTitleRevision : SearchQuery
   {
      private string m_titleCriteria;
      private string m_revisionCriteria;
      private string m_collaborativeSpace = null;

      public SearchByTitleRevision(string _titleCriteria, string _revisionCriteria, string _collaborativeSpace = null)
      {
         m_titleCriteria = _titleCriteria;
         m_revisionCriteria = _revisionCriteria;
         m_collaborativeSpace = _collaborativeSpace;
      }

      public override string GetSearchString()
      {
         if (null == m_collaborativeSpace)
         {
            return string.Format("label:\"{0}\" AND revision:{1}", m_titleCriteria, m_revisionCriteria);
         }
         else
         {
            return string.Format("label:\"{0}\" AND revision:{1} AND project:({2})", m_titleCriteria, m_revisionCriteria, m_collaborativeSpace);
         }
      }
   }
}
